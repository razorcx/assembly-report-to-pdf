using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using Tekla.Structures.Model;

namespace AssemblyReport
{
	public partial class AssemblyReportForm : Form
	{
		private readonly Model _model = new Model();
		private List<Assembly> _assemblies;
		private List<MainAssembly> _assemblyReport;

		public AssemblyReportForm()
		{
			InitializeComponent();

			textBoxName.Text = _model.GetProjectInfo().Name;
			textBoxNumber.Text = _model.GetProjectInfo().ProjectNumber;
			textBoxBuilder.Text = _model.GetProjectInfo().Builder;
		}

		private void InitializePhaseNumbers()
		{
			var phaseNumbers = _assemblies.Select(a =>
				{
					var phaseNumber = -1;
					a.GetReportProperty("PHASE", ref phaseNumber);
					return phaseNumber;
				})
				.Distinct()
				.ToList();

			phaseNumbers.Sort();

			var phaseNumbersSorted = phaseNumbers.Select(p => p.ToString()).ToList();

			phaseNumbersSorted.Insert(0, string.Empty);
			comboBoxPhase.DataSource = phaseNumbersSorted;
		}

		private void UpdateTreeView()
		{
			var assyList = _assemblies.AsParallel()
				.Where(a => a.GetSubAssemblies().ToArray().Any())
				.OfType<Assembly>()
				.ToList();

			_assemblyReport = assyList.AsParallel().Select(a =>
				{
					var assyMark = string.Empty;
					a.GetReportProperty("ASSEMBLY_POS", ref assyMark);
					var phaseNumber = -1;
					a.GetReportProperty("PHASE", ref phaseNumber);
					var subAssemblies = a.GetSubAssemblies().OfType<Assembly>().ToList();

					var assy = new MainAssembly
					{
						AssemblyName = a.Name,
						AssemblyMark = assyMark,
						PhaseNumber = phaseNumber,
						SubAssemblies = subAssemblies
							.Select(GetSubAssembly)
							.OrderBy(s => s.MainPartMark)
							.ToList()
					};
					return assy;
				})
				.OrderBy(a => a.AssemblyMark)
				.ToList();

			var view = new List<dynamic>();
			_assemblyReport.ForEach(a =>
			{
				view.Add(a);
				a.SubAssemblies.ForEach(sa => view.Add(sa));
			});

			treeView1.Nodes.Clear();

			_assemblyReport.ForEach(a =>
			{
				var treeNodes = a.SubAssemblies.Select(sa =>
				{
					var subAssyText = $"Mark:{sa.SubAssemblyMark} Name: {sa.SubAssemblyName} Phase: {sa.PhaseNumber}";
					return new TreeNode(subAssyText);
				}).ToArray();
				var assyText = $"Mark:{a.AssemblyMark} Name: {a.AssemblyName} Phase: {a.PhaseNumber}";
				var treeNode = new TreeNode(assyText, treeNodes);
				treeView1.Nodes.Add(treeNode);
			});
		}

		private SubAssembly GetSubAssembly(Assembly sa)
		{
			var subAssyMark = string.Empty;
			sa.GetReportProperty("ASSEMBLY_POS", ref subAssyMark);
			var subAssyPhaseNumber = -1;
			sa.GetReportProperty("PHASE", ref subAssyPhaseNumber);
			var mainPart = (Part)sa.GetMainPart();

			var subAssy = new SubAssembly()
			{
				SubAssemblyName = sa.Name,
				SubAssemblyMark = subAssyMark,
				PhaseNumber = subAssyPhaseNumber,
				MainPartName = mainPart?.Name,
				MainPartMark = mainPart?.GetPartMark(),
			};
			return subAssy;
		}

		private void GetAssemblies(string phase)
		{
			ModelObjectEnumerator.AutoFetch = true;

			_assemblies = new Model()
				.GetModelObjectSelector()
				.GetAllObjectsWithType(ModelObject.ModelObjectEnum.ASSEMBLY)
				.ToList()
				.OfType<Assembly>()
				.ToList();

			if (!string.IsNullOrEmpty(phase))
				_assemblies = _assemblies.Where(a =>
				{
					var phaseNumber = -1;
					a.GetReportProperty("PHASE", ref phaseNumber);
					return phaseNumber.ToString() == phase;
				}).ToList();
		}

		private void comboBoxPhase_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetAssemblies(comboBoxPhase.Text);
			UpdateTreeView();
		}

		private void buttonGetAssemblyReport_Click(object sender, System.EventArgs e)
		{
			GetAssemblies(string.Empty);

			InitializePhaseNumbers();

			UpdateTreeView();
		}

		private void buttonExportToPDF_Click(object sender, EventArgs e)
		{
			ExportToPdf();
		}

		private void ExportToPdf()
		{
			try
			{
				var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
				string path = $"d:\\RazorCX\\Development\\{_model.GetProjectInfo().Name} Assembly Report.pdf";
				PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
				pdfDoc.Open();

				var imagepath = @"D:\RazorCX\Logos\Logo.png";
				using (FileStream fs = new FileStream(imagepath, FileMode.Open))
				{
					var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
					png.ScalePercent(5f);
					png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
					pdfDoc.Add(png);
				}

				var spacer = new Paragraph("")
				{
					SpacingBefore = 10f,
					SpacingAfter = 10f,
				};
				pdfDoc.Add(spacer);

				var headerTable = new PdfPTable(new[] { .75f, 2f })
				{
					HorizontalAlignment = Left,
					WidthPercentage = 75,
					DefaultCell = { MinimumHeight = 22f }
				};

				headerTable.AddCell("Date");
				headerTable.AddCell(DateTime.Now.ToString());
				headerTable.AddCell("Name");
				headerTable.AddCell(textBoxName.Text);
				headerTable.AddCell("Project Number");
				headerTable.AddCell(textBoxNumber.Text);
				headerTable.AddCell("Builder");
				headerTable.AddCell(textBoxBuilder.Text);

				pdfDoc.Add(headerTable);
				pdfDoc.Add(spacer);

				var columnCount = 4;
				var columnWidths = new[] { 1f, 1f, 2f, 1f };

				var table = new PdfPTable(columnWidths)
				{
					HorizontalAlignment = Left,
					WidthPercentage = 100,
					DefaultCell = { MinimumHeight = 22f }
				};

				var cell = new PdfPCell(new Phrase("ASSEMBLY REPORT"))
				{
					Colspan = columnCount,
					HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
					MinimumHeight = 30f
				};

				table.AddCell(cell);

				var markCell = new PdfPCell(new Phrase("MARK"))
				{
					Colspan = 2,
				};
				table.AddCell(markCell);
				table.AddCell("NAME");
				table.AddCell("PHASE");

				_assemblyReport.ForEach(a =>
				{
					markCell = new PdfPCell(new Phrase(a.AssemblyMark))
					{
						Colspan = 2,
					};
					table.AddCell(markCell);
					table.AddCell(a.AssemblyName);
					table.AddCell(a.PhaseNumber.ToString());

					a.SubAssemblies.ForEach(sa =>
					{
						table.AddCell(string.Empty);
						table.AddCell(sa.SubAssemblyMark);
						table.AddCell(sa.SubAssemblyName);
						table.AddCell(sa.PhaseNumber.ToString());
					});

					cell = new PdfPCell(new Phrase(" "))
					{
						Colspan = columnCount,
						HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
						MinimumHeight = 30f
					};
					table.AddCell(cell);
				});

				pdfDoc.Add(table);

				pdfDoc.Close();
			}
			catch (Exception ex)
			{

			}
		}
	}
}

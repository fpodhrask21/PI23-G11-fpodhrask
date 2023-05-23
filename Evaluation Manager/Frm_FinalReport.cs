using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class Frm_FinalReport : Form
    {
        public Frm_FinalReport()
        {
            InitializeComponent();
        }

        private List<StudentReportView> GenerateStudentReport()
        {
            var allStudents = StudentRepository.GetStudents();
            var examReports = new List<StudentReportView>();

            foreach (var student in allStudents)
            {
                if (student.HasSignature())
                {
                    var examReport = new StudentReportView(student);
                    examReports.Add(examReport);
                }
            }
            return examReports;
        }

        private void Frm_FinalReport_Load(object sender, EventArgs e)
        {
            var results = GenerateStudentReport();
            dgw_Results.DataSource = results;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

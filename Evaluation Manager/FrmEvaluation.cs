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
    public partial class FrmEvaluation : Form
    {
        public FrmEvaluation(Models.Student student)
        {
            InitializeComponent();
            Text = student.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmEvaluation_Load(object sender, EventArgs e)
        {
            var activities = ActivityRepository.GetActivities();
            cboActivities.DataSource = activities;  
        }

        private void SetFormText()
        {

        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentActivity = cboActivities.SelectedItem as Activity;
            txtActivityDescription.Text = currentActivity.Description;
            txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" + currentActivity.MaxPoints;
            txtMinForSignature.Text = currentActivity.MinPointsForSignature;

            numPoints.Minimum = 0;
            numPoints.Maximum = currentActivity.MaxPoints;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

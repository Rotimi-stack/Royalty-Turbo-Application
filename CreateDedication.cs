using Royalty_Turbo.Common.Data;
using Royalty_Turbo.Controller;
using Royalty_Turbo.DataAccess.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public partial class CreateDedication : Form
    {
        private MemberData _mem;
        private WorkerData _wor;
        private PromotionData _pro;
        private MarriageData _marriage;
        private DedicationData _dedication;
        private DepartmentRecordData _record;
        private EquipmentData _equipment;
        private ProgramItenaryData _program;



        public readonly ISQL _db;
        private IMemberController _memberController;
        private CodeStatusType _statusType;
        private CodeSexType _sexType;
        private CodeNationalityType _nat;
        private CodeStateType _state;
        private ISetUpController _setUpController;
        private bool _isEditMode;
        public CreateDedication(string connectionString, DedicationData dedication = null)
        {
            InitializeComponent();
            SetCurvedEdges();
            _dedication = dedication ?? new DedicationData(); // If no member is provided, create a new one
            _isEditMode = dedication != null;
            _memberController = new MemberController(connectionString);
            _statusType = new CodeStatusType();
            _sexType = new CodeSexType();
            _nat = new CodeNationalityType();
            _state = new CodeStateType();
            _setUpController = new SetUpController(connectionString);
            MakePanelCircular(panel7);
            ClearInputFields();


            if (_isEditMode)
            {
                PopulateFields();
            }
            else
            {
                ClearInputFields();
            }
           
            
        }

        private void PopulateFields()
        {
            textDedName.Text = _dedication.Name;
            texDedCert.Text = _dedication.CertificateName;
            textOffiMin.Text = _dedication.OfficiatingMinisters;
            dtpDedDate.Value = _dedication.DedicationDate;
            dateDed.Value = _dedication.DateCreated;

        }
        private void SetCurvedEdges()
        {
            // Define the new width and height for the form (adjust as needed)
            int newWidth = 500;
            int newHeight = 500;

            // Define the radius of the curves (adjust as needed)
            int radius = 20;

            // Create a GraphicsPath to define the shape
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
            path.AddArc(new Rectangle(newWidth - radius * 2, 0, radius * 2, radius * 2), -90, 90);
            path.AddArc(new Rectangle(newWidth - radius * 2, newHeight - radius * 2, radius * 2, radius * 2), 0, 90);
            path.AddArc(new Rectangle(0, newHeight - radius * 2, radius * 2, radius * 2), 90, 90);
            path.CloseFigure();

            // Set the form's region to the defined shape
            this.Region = new Region(path);

            // Set the new size of the form
            this.Size = new Size(newWidth, newHeight);
        }

        private void MakePanelCircular(Panel panel)
        {
            // Resize the panel to 100x100 pixels
            panel.Size = new Size(40, 50);

            // Create a circular region for the panel
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }

        private void ClearInputFields()
        {
            // Clear input fields
            textDedName.Text = "";
            texDedCert.Text = "";
            textOffiMin.Text = "";

        }
        protected void DisplayMessage(string message, MessageBoxIcon icon, int timeout = 1000)
        {
            MessageBox.Show(message, "Member", MessageBoxButtons.OK, icon);
            Task.Delay(timeout).ContinueWith(t =>
            {
                if (IsHandleCreated)
                {
                    Invoke(new Action(() =>
                    {
                        errorProvider1.Clear();
                    }));
                }
            });
        }

        private async void btnAddDed_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                var getWorker = _memberController.GetDedicationByName(textDedName.Text);
                if (getWorker != null)
                {
                    DisplayMessage("Dedication Name  already captured, Kindly add name of dedication and participants name", MessageBoxIcon.Error);
                    ClearInputFields(); // Clear input fields after successful save
                    return;
                }
            }


            Control ctlr = this;
            string strError = null;



           
            _dedication.Name = textDedName.Text;
            _dedication.CertificateName = texDedCert.Text;
            _dedication.OfficiatingMinisters = textOffiMin.Text;



          

            if (string.IsNullOrWhiteSpace (_dedication.Name))
            {
                ctlr = textDedName;
                strError = "Please enter Firstname";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_dedication.CertificateName))
            {
                ctlr = texDedCert;
                strError = "Please enter Lastname";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_dedication.OfficiatingMinisters))
            {
                ctlr = textOffiMin;
                strError = "Please enter Middlename";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }



            _dedication.DedicationDate = dtpDedDate.Value.Date;
            _dedication.DateCreated = dateDed.Value.Date;
            _dedication.DateModified = dateDed.Value.Date;
            if (_isEditMode)
            {
                // Call the Update method in the MemberController
                bool updateResult = await _memberController.UpdateDedication(_dedication);

                if (updateResult)
                {
                    DisplayMessage("Dedication record updated successfully!", MessageBoxIcon.Information);
                    this.Close(); // Close the form after successful update
                }
                else
                {
                    DisplayMessage("Error occurred while updating dedication record!", MessageBoxIcon.Error);
                }
            }
            else
            {
                // Call the Save method in the MemberController
                bool saveResult = await _memberController.SaveDedication(_dedication);

                if (saveResult)
                {
                    DisplayMessage("Dedication added successfully!", MessageBoxIcon.Information);
                    ClearInputFields(); // Clear input fields after successful save
                }
                else
                {
                    DisplayMessage("Error occurred while saving dedication!", MessageBoxIcon.Error);
                }
            }
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }

}
    


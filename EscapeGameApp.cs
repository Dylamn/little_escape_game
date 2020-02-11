using System;
using System.Drawing;
using System.Windows.Forms;

namespace EscapeGame
{
    public partial class EscapeGameApp : Form
    {
        private const int MAX_ATTEMPTS = 3;
        private int m_ActualAttempt = 0;
        private bool m_canBeClosed = false;

        public string Proposition { get; set; } = "";

        public EscapeGameApp()
        {
            InitializeComponent();
            PopulateTreeView();            
        }

        #region Events
        #region authPanel Events Components
        private void Timer_Tick(object sender, EventArgs e)
        {
            ManageProgressTimeBar(); // This method will decrement the Value attribute of the Vertical Progress Bar and check if the time is over.
        }

        private void EscapeGame_Load(object sender, EventArgs e)
        {
            UpdateAttemptsText(); // Dynamically defines the maximum number of attempts in the Text property of lblAttempts.
        }

        private void Input_pwd_TextChanged(object sender, EventArgs e)
        {
            if (errorProvider.GetError(input_pwd) != "") // Check if the ErrorProvider is Active or not.
            {
                input_pwd.BorderColor = CustomTextBox.DefaultColor;
                errorProvider.Clear();
            }

            this.Proposition = input_pwd.Text;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            input_pwd.Focus(); // Focus the input.

            if (Proposition.Length == 0) // Nothing has been written.
            {
                SetVisualError(Properties.Resources.EmptyPwdInput);
                return;
            }
            else if (Proposition == Properties.Resources.PASSWORD) // The password is found.
            {
                authPanel.Visible = false;
                docsPanel.Visible = true;

                m_canBeClosed = true; // The form can be closed.
                this.ControlBox = true;

                return;
            }
            else if (m_ActualAttempt == MAX_ATTEMPTS) // Maximum attempts reached. The game is over.
            {
                timerTime.Enabled = false;

                MessageBox.Show(Properties.Resources.DefeatMessage);
                
                this.m_canBeClosed = true; // The form can be closed.

                this.Close(); // Will close the form, this is managed in the FormClosing event.
            }
            else if (Proposition != Properties.Resources.PASSWORD && m_ActualAttempt < MAX_ATTEMPTS) // Wrong password, we increment the attempt number.
            {
                input_pwd.Clear(); // We clear the wrong password.

                SetVisualError(Properties.Resources.WrongPwdInput); // Then we indicate the error.

                UpdateAttemptsText(); 
                return;
            }
        }

        // Prevents from the Alt+F4 hotkey combination.
        private void EscapeGameApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_canBeClosed == true)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        #endregion

        #region docsPanel Events Components
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion

        #region Components Update Methods
        /// <summary>
        /// This method refresh the Text property of the <see cref="lblAttempt"/>.
        /// </summary>
        private void UpdateAttemptsText()
        {
            m_ActualAttempt++;
            // @ will be replaced by the maximum number of attempts.
            lblAttempt.Text = Properties.Resources.AttemptsString.Replace("@", MAX_ATTEMPTS.ToString());
            // _ will be replaced by the current attempt number.
            lblAttempt.Text = lblAttempt.Text.Replace("_", m_ActualAttempt.ToString());
        }

        /// <summary>
        /// This method manages the value and color of the <see cref="verticalProgressBar1"/> over time.
        /// /// If the Value property is equal to 0, the user loses and the form is closed.
        /// </summary>
        private void ManageProgressTimeBar()
        {
            if (verticalProgressBar1.Value > 0)
            {
                verticalProgressBar1.Value--; // Decrement the Value property.

                if (verticalProgressBar1.Value <= verticalProgressBar1.Maximum / 2 && verticalProgressBar1.Value >= verticalProgressBar1.Maximum / 5)
                {
                    verticalProgressBar1.Color = Color.Orange;
                    return;
                }
                if (verticalProgressBar1.Value <= verticalProgressBar1.Maximum / 5)
                {
                    verticalProgressBar1.Color = Color.Red;
                    return;
                }
            }
            else if (verticalProgressBar1.Value == 0) // The form will be closed.
            {
                timerTime.Enabled = false;
                MessageBox.Show(this, Properties.Resources.OutOfTime, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                

                m_canBeClosed = true;
                this.Close();
            }
        }

        /// <summary>
        /// Change the color border on the <see cref="CustomTextBox"/> and set the error for the binded <see cref="ErrorProvider"/>.
        /// </summary>
        private void SetVisualError(string message)
        {
            input_pwd.BorderColor = Color.Red;
            errorProvider.SetError(input_pwd, message); 
        }

        /// <summary>
        /// This method will fill the <see cref="treeView"/> component.
        /// </summary>
        private void PopulateTreeView()
        {
            
            treeView.BeginUpdate();

            // This node is a folder that contains all the files.
            TreeNode rootNode = new TreeNode()
            {
                Name = "rootNode",
                Text = "Top Secret",
                ImageIndex = 1,
                SelectedImageIndex = 1
            };

            // We create all the files contained in the folder (in the rootNode)
            rootNode.Nodes.Add(new TreeNode("USA", 0, 0));
            rootNode.Nodes.Add(new TreeNode("Irak2003", 0, 0));
            rootNode.Nodes.Add(new TreeNode("France2019", 0, 0));
            rootNode.Nodes.Add(new TreeNode("Crimée", 0, 0));
            rootNode.Nodes.Add(new TreeNode("Egypte", 0, 0));
            rootNode.Nodes.Add(new TreeNode("Iran", 0, 0));

            this.treeView.Nodes.Add(rootNode); // We add the rootNode to the TreeView

            treeView.EndUpdate();
        }
        #endregion
    }
}

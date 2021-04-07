using MTPLib;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ShadowMotionSwapper {
    public partial class Form1 : Form {

        private MotionPackage targetPackage, donorPackage;
        
        BindingSource targetBinding = new BindingSource();
        BindingSource donorBinding = new BindingSource();

        public Form1() {
            InitializeComponent();
            targetBinding.DataSource = targetPackage;
            listBoxTarget.DataSource = targetBinding;
            listBoxTarget.DisplayMember = "Entries";
        }

        private void buttonOpenTarget_Click(object sender, EventArgs e) {
            var dialog = new Ookii.Dialogs.WinForms.VistaOpenFileDialog {
                Filter = "Motion files (*.mtp)|*.mtp|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            if (!dialog.FileName.ToLower().EndsWith(".mtp")) {
                MessageBox.Show("Pick an 'MTP' file", "Try Again");
                return;
            }
            var data = File.ReadAllBytes(dialog.FileName);
            targetPackage = MotionPackage.FromMtp(data);
            //displayTargetPackage = CollectionViewSource.GetDefaultView(targetPackage.Entries);
            //listBoxTarget.ItemsSource = displayTargetPackage;
            targetBinding.DataSource = targetPackage;
            targetBinding.DataMember = "Entries";

            //listBoxTarget.DataSource = new BindingList<ManagedAnimationEntry>(targetPackage.Entries);
        }

        private void buttonOpenDonor_Click(object sender, EventArgs e) {
            var dialog = new Ookii.Dialogs.WinForms.VistaOpenFileDialog {
                Filter = "Motion files (*.mtp)|*.mtp|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            if (!dialog.FileName.ToLower().EndsWith(".mtp")) {
                MessageBox.Show("Pick an 'MTP' file", "Try Again");
                return;
            }
            var data = File.ReadAllBytes(dialog.FileName);
            donorPackage = MotionPackage.FromMtp(data);
            //displayDonorPackage = CollectionViewSource.GetDefaultView(donorPackage.Entries);
            //listBoxDonor.ItemsSource = displayDonorPackage;
            //listBoxDonor.DataSource = new BindingList<ManagedAnimationEntry>(donorPackage.Entries);

        }

        private void buttonExport_Click(object sender, EventArgs e) {
            if (targetPackage == null)
                return;
            var dialog = new Ookii.Dialogs.WinForms.VistaSaveFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            if (dialog.FileName != "") {
                File.WriteAllBytes(dialog.FileName, targetPackage.ToMtp());
            }
        }

        private void buttonMap_Click(object sender, EventArgs e) {
            if (listBoxTarget.SelectedIndex == -1 || listBoxDonor.SelectedIndex == -1)
                return;
            var targetEntry = targetPackage.Entries[listBoxTarget.SelectedIndex];
            var donorEntry = donorPackage.Entries[listBoxDonor.SelectedIndex];

            // TODO: Add additional conditionals to allow:
            // - Copy name from donor (generally bad idea)

            if (checkBoxCopyProps.Checked == true) {
                /*targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(targetEntry.FileName, donorEntry.FileData, donorEntry.Tuples);*/
                targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(donorEntry.FileName, donorEntry.FileData, donorEntry.Tuples);
            } else {
                targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(targetEntry.FileName, donorEntry.FileData, targetEntry.Tuples);
            }

            //listBoxTarget.Data
            //displayTargetPackage.Refresh();
        }
    }
}

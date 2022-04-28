using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MTPLib;

namespace ShadowMotionSwapper {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        MotionPackage targetPackage, donorPackage;
        ICollectionView displayTargetPackage, displayDonorPackage;
        Window swapLog;
        string log;

        public MainWindow() {
            InitializeComponent();
        }

        private void buttonMap_Click(object sender, RoutedEventArgs e) {
            if (listBoxTarget.SelectedIndex == -1 || listBoxDonor.SelectedIndex == -1)
                return;
            var targetEntry = targetPackage.Entries[listBoxTarget.SelectedIndex];
            var donorEntry = donorPackage.Entries[listBoxDonor.SelectedIndex];

            // TODO: Add additional conditionals to allow:
            // - Copy name from donor (generally bad idea)


            if (checkboxCopyProps.IsChecked == true) {
                log += "REPLACED " + targetEntry.FileName + "\nWITH " + donorEntry.FileName + "\nAND used props from " + donorEntry.FileName + "\n\n";
                targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(targetEntry.FileName, donorEntry.FileData, donorEntry.Tuples);
            } else {
                log += "REPLACED " + targetEntry.FileName + "\nWITH " + donorEntry.FileName + "\nAND kept props from " + targetEntry.FileName + "\n\n";
                targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(targetEntry.FileName, donorEntry.FileData, targetEntry.Tuples);
            }
            if (swapLog != null)
            {
                TextBox tB = (TextBox)swapLog.FindName("TextBox_SwapLog");
                tB.Text = log;
            }
            displayTargetPackage.Refresh();
        }

        private void buttonExport_Click(object sender, RoutedEventArgs e) {
            if (targetPackage == null)
                return;
            var dialog = new Ookii.Dialogs.Wpf.VistaSaveFileDialog();
            if (dialog.ShowDialog() == false) {
                return;
            }
            if (dialog.FileName != "") {
                File.WriteAllBytes(dialog.FileName, targetPackage.ToMtp());
            }
        }

        private void buttonSwapLog_Click(object sender, RoutedEventArgs e)
        {
            if (swapLog == null)
                swapLog = new SwapLog(log);
            swapLog.Show();
        }

        private void buttonResetLog_Click(object sender, RoutedEventArgs e)
        {
            if (swapLog != null)
            {
                TextBox tB = (TextBox)swapLog.FindName("TextBox_SwapLog");
                tB.Text = "";
            }
            log = "";
        }

        private void buttonOpenTarget_Click(object sender, RoutedEventArgs e) {
            var dialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog {
                Filter = "Motion files (*.mtp)|*.mtp|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == false) {
                return;
            }
            if (!dialog.FileName.ToLower().EndsWith(".mtp")) {
                MessageBox.Show("Pick an 'MTP' file", "Try Again");
                return;
            }
            var data = File.ReadAllBytes(dialog.FileName);
            targetPackage = MotionPackage.FromMtp(data);
            displayTargetPackage = CollectionViewSource.GetDefaultView(targetPackage.Entries);
            listBoxTarget.ItemsSource = displayTargetPackage;
        }

        private void buttonOpenDonor_Click(object sender, RoutedEventArgs e) {
            var dialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog {
                Filter = "Motion files (*.mtp)|*.mtp|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == false) {
                return;
            }
            if (!dialog.FileName.ToLower().EndsWith(".mtp")) {
                MessageBox.Show("Pick an 'MTP' file", "Try Again");
                return;
            }
            var data = File.ReadAllBytes(dialog.FileName);
            donorPackage = MotionPackage.FromMtp(data);
            displayDonorPackage = CollectionViewSource.GetDefaultView(donorPackage.Entries);
            listBoxDonor.ItemsSource = displayDonorPackage;
        }
    }
}

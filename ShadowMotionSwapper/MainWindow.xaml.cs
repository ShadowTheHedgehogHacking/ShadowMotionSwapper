using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MTPLib;

namespace ShadowMotionSwapper {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        MotionPackage targetPackage, donorPackage;
        ICollectionView displayTargetPackage, displayDonorPackage;

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
                if (checkboxInfoPopup.IsChecked == true) {
                    MessageBox.Show("REPLACED " + targetEntry.FileName + "\nWITH " + donorEntry.FileName + "\nAND used props from " + donorEntry.FileName);
                }
                targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(targetEntry.FileName, donorEntry.FileData, donorEntry.Tuples);
            } else {
                    if (checkboxInfoPopup.IsChecked == true) {
                    MessageBox.Show("REPLACED " + targetEntry.FileName + "\nWITH " + donorEntry.FileName + "\nAND kept props from " + targetEntry.FileName);
                }
                targetPackage.Entries[listBoxTarget.SelectedIndex] = new ManagedAnimationEntry(targetEntry.FileName, donorEntry.FileData, targetEntry.Tuples);
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

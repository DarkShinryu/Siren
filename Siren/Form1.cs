using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siren
{
    public partial class Form1 : Form
    {
        public static bool _loaded = false;
        public string _existingFilename;
        private static bool _openSaveException = false;

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        public Form1()
        {
            InitializeComponent();

            buttonSave.Enabled = false;
            panelMain.Enabled = false;
            panelSellPrice.BackColor = Color.WhiteSmoke;

            #region Event Handlers

            numBuy.TextChanged += (sender, args) => Worker.UpdateVariables(0, numBuy.Text);
            numSellMult.TextChanged += (sender, args) => Worker.UpdateVariables(1, numSellMult.Text);

            #endregion
        }

        #region Open File

        private async void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open FF8 price.bin";
            openFileDialog.Filter = "FF8 price|*.bin";
            openFileDialog.FileName = "price.bin";

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            {
                try
                {
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var BR = new BinaryReader(fileStream))
                        {
                            Worker.ReadKernel(BR.ReadBytes((int)fileStream.Length));
                        }
                    }
                    _existingFilename = openFileDialog.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot open the file {0}, maybe it's locked by another software?", Path.GetFileName(openFileDialog.FileName)), "Error Opening File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    _openSaveException = true;
                }
            }

            if (!_openSaveException)
            {
                panelMain.Enabled = true;
                panelSellPrice.BackColor = Color.White;

                Worker.CheckKernel = File.ReadAllBytes(_existingFilename);

                KeyUp += new KeyEventHandler(Form1_KeyUp);
                numBuy.TextChanged += new EventHandler(Form1_Objects);
                numSellMult.TextChanged += new EventHandler(Form1_Objects);

                lbItems.SelectedIndex = 0;
                lbItems.Items[lbItems.SelectedIndex] = lbItems.SelectedItem; //used to refresh, useful if opening files more than once

                string language = cbLanguages.GetItemText(cbLanguages.SelectedItem);
                switch (language)
                {
                    case "English":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " loaded successfully";
                        toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " loaded";
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Ready";
                        break;

                    case "French":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " chargé avec succès";
                        toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " chargé";
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Prêt";
                        break;

                    case "German":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " erfolgreich geladen";
                        toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " geladen";
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Bereit";
                        break;

                    case "Italian":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " caricato con successo";
                        toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " caricato";
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Pronto";
                        break;

                    case "Spanish":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " cargado correctamente";
                        toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " cargado";
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Listo";
                        break;
                }
            }
            _openSaveException = false;
        }

        #endregion

        #region Save File

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(_existingFilename)) && Worker.Kernel != null)
            {
                try
                {
                    File.WriteAllBytes(_existingFilename, Worker.Kernel);
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot save the file {0}, maybe it's locked by another software?", Path.GetFileName(_existingFilename)),
                        "Error Saving File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    _openSaveException = true;
                }
            }
            if (_openSaveException == false)
            {
                Worker.CheckKernel = File.ReadAllBytes(_existingFilename);
                buttonSave.Enabled = false;

                string language = cbLanguages.GetItemText(cbLanguages.SelectedItem);
                switch (language)
                {
                    case "English":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " saved successfully"; ;
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Ready";
                        break;

                    case "French":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " enregistré avec succès"; ;
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Prêt";
                        break;

                    case "German":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " erfolgreich gespeichert"; ;
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Bereit";
                        break;

                    case "Italian":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " salvato con successo"; ;
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Pronto";
                        break;

                    case "Spanish":
                        toolStripLabelStatus.Text = Path.GetFileName(_existingFilename) + " guardado exitosamente"; ;
                        statusStrip.BackColor = Color.FromArgb(255, 242, 242, 0);
                        toolStripLabelStatus.BackColor = Color.FromArgb(255, 242, 242, 0);
                        await Task.Delay(4000);
                        statusStrip.BackColor = Color.LightGray;
                        toolStripLabelStatus.BackColor = Color.LightGray;
                        toolStripLabelStatus.Text = "Listo";
                        break;
                }
            }
            _openSaveException = false;
        }

        #endregion

        #region Aboutbox

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        #endregion

        #region Check when to enable save button

        private void CheckSaveButton()
        {
            if (Worker.Kernel.Length == Worker.CheckKernel.Length && memcmp(Worker.Kernel, Worker.CheckKernel, Worker.Kernel.Length) == 0)
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            CheckSaveButton();
        }

        private void Form1_Objects(object sender, EventArgs e)
        {
            CheckSaveButton();
        }

        #endregion

        #region Translations

        private void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                applyResources(resources, ctl.Controls);
            }
        }

        private void cbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = cbLanguages.GetItemText(cbLanguages.SelectedItem);

            switch (language)
            {
                case "English":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
                        ComponentResourceManager resourcesEn = new ComponentResourceManager(typeof(Form1));
                        resourcesEn.ApplyResources(this, "$this");
                        applyResources(resourcesEn, this.Controls);
                        buttonOpen.Text = "Open...";
                        buttonSave.Text = "Save";
                        buttonAbout.Text = "About...";
                        toolStripLabelStatus.Text = "Ready";
                        labelBuy.Text = "Buy Price (G)";
                        labelSellMult.Text = "Sell Price Multiplier";
                        labelSell.Text = "Sell Price*";
                        labelSellFormula.Text = "*Sell Price = ((Buy Price / 10) / 2) * Sell Mult";
                        if (_existingFilename != null)
                            toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " loaded";
                        else
                            toolStripLabelFile.Text = "No file is loaded";

                        lbItems.Items.Clear();
                        string[] itemsListEn = Properties.Resources.ItemsListEn.Split('\n');
                        foreach (var line in itemsListEn)
                        {
                            lbItems.Items.Add(line);
                        }
                        break;
                    }


                case "French":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr");
                        ComponentResourceManager resourcesFr = new ComponentResourceManager(typeof(Form1));
                        resourcesFr.ApplyResources(this, "$this");
                        applyResources(resourcesFr, this.Controls);
                        buttonOpen.Text = "Ouvrir...";
                        buttonSave.Text = "Enregistrer";
                        buttonAbout.Text = "Informations...";
                        toolStripLabelStatus.Text = "Prêt";
                        labelBuy.Text = "Acheter Prix (G)";
                        labelSellMult.Text = "Vendre Prix Multiplicateur";
                        labelSell.Text = "Vendre Prix*";
                        labelSellFormula.Text = "*Vendre Prix = ((Acheter Prix / 10) / 2) * Vendre Mult";
                        if (_existingFilename != null)
                            toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " chargé";
                        else
                            toolStripLabelFile.Text = "Aucun fichier est chargé";

                        lbItems.Items.Clear();
                        string[] itemsListFr = Properties.Resources.ItemsListFr.Split('\n');
                        foreach (var line in itemsListFr)
                        {
                            lbItems.Items.Add(line);
                        }
                        break;
                    }

                case "German":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de");
                        ComponentResourceManager resourcesDe = new ComponentResourceManager(typeof(Form1));
                        resourcesDe.ApplyResources(this, "$this");
                        applyResources(resourcesDe, this.Controls);
                        buttonOpen.Text = "Öffnen...";
                        buttonSave.Text = "Speichern";
                        buttonAbout.Text = "Informationen...";
                        toolStripLabelStatus.Text = "Bereit";
                        labelBuy.Text = "Kaufen Preis (G)";
                        labelSellMult.Text = "Verkaufspreis Multiplikator";
                        labelSell.Text = "Verkaufspreis*";
                        labelSellFormula.Text = "*Verkaufspreis = ((Kaufen Preis / 10) / 2) * Verkaufspreis Mult";
                        if (_existingFilename != null)
                            toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " geladen";
                        else
                            toolStripLabelFile.Text = "Keine datei geladen wird";

                        lbItems.Items.Clear();
                        string[] itemsListDe = Properties.Resources.ItemsListDe.Split('\n');
                        foreach (var line in itemsListDe)
                        {
                            lbItems.Items.Add(line);
                        }
                        break;
                    }

                case "Italian":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("it");
                        ComponentResourceManager resourcesIt = new ComponentResourceManager(typeof(Form1));
                        resourcesIt.ApplyResources(this, "$this");
                        applyResources(resourcesIt, this.Controls);
                        buttonOpen.Text = "Apri...";
                        buttonSave.Text = "Salva";
                        buttonAbout.Text = "Informazioni...";
                        toolStripLabelStatus.Text = "Pronto";
                        labelBuy.Text = "Prezzo Acquisto (G)";
                        labelSellMult.Text = "Molt. Prezzo Vendita";
                        labelSell.Text = "Prezzo Vendita*";
                        labelSellFormula.Text = "*Prezzo Vendita = ((P. Acquisto / 10) / 2) * Molt. P. Vendita";
                        if (_existingFilename != null)
                            toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " caricato";
                        else
                            toolStripLabelFile.Text = "Nessun file è stato caricato";

                        lbItems.Items.Clear();
                        string[] itemsListIt = Properties.Resources.ItemsListIt.Split('\n');
                        foreach (var line in itemsListIt)
                        {
                            lbItems.Items.Add(line);
                        }
                        break;
                    }

                case "Spanish":
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es");
                        ComponentResourceManager resourcesEs = new ComponentResourceManager(typeof(Form1));
                        resourcesEs.ApplyResources(this, "$this");
                        applyResources(resourcesEs, this.Controls);
                        buttonOpen.Text = "Abrir...";
                        buttonSave.Text = "Guardar";
                        buttonAbout.Text = "Informaciones...";
                        toolStripLabelStatus.Text = "Listo";
                        labelBuy.Text = "Precio de Compra (G)";
                        labelSellMult.Text = "Precio de venta mult.";
                        labelSell.Text = "Precio de venta*";
                        labelSellFormula.Text = "*P. de venta = ((P. de Compra / 10) / 2) * P. de venta mult";
                        if (_existingFilename != null)
                            toolStripLabelFile.Text = Path.GetFileName(_existingFilename) + " cargado";
                        else
                            toolStripLabelFile.Text = "Ningún archivo es cargado";

                        lbItems.Items.Clear();

                        string[] itemsListEs = Properties.Resources.ItemsListEs.Split('\n');
                        foreach (var line in itemsListEs)
                        {
                            lbItems.Items.Add(line);
                        }
                        break;
                    }
            }
            if (_existingFilename != null)
                lbItems.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Siren"))
                {
                    if (key != null)
                    {
                        object savedLanguage = key.GetValue("Language");


                        if (savedLanguage != null && ((string)savedLanguage == "English" || (string)savedLanguage == "French" ||
                            (string)savedLanguage == "German" || (string)savedLanguage == "Italian" || (string)savedLanguage == "Spanish"))
                            cbLanguages.SelectedItem = savedLanguage;
                        else
                            cbLanguages.SelectedItem = "English";
                    }
                    else
                        cbLanguages.SelectedItem = "English";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Closing Application (Show save message and save current language to registry)

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonSave.Enabled)
            {
                string language = cbLanguages.GetItemText(cbLanguages.SelectedItem);

                switch (language)
                {
                    case "English":
                        {
                            DialogResult dialogResult = MessageBox.Show("Save changes to " + Path.GetFileName(_existingFilename) + " before closing?", "Close",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    File.WriteAllBytes(_existingFilename, Worker.Kernel);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show
                                        (String.Format("I cannot save the file {0}, maybe it's locked by another software?", Path.GetFileName(_existingFilename)),
                                        "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    _openSaveException = true;
                                }

                                if (_openSaveException == true)
                                {
                                    e.Cancel = true;
                                }
                            }

                            else if (dialogResult == DialogResult.Cancel)
                                e.Cancel = true;
                            _openSaveException = false;

                            break;
                        }


                    case "French":
                        {
                            DialogResult dialogResult = MessageBox.Show("Enregistrer les modifications à " + Path.GetFileName(_existingFilename) + " avant de clôturer?", "Fermer",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    File.WriteAllBytes(_existingFilename, Worker.Kernel);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show
                                        (String.Format("Je ne peux pas enregistrer le fichier {0}, peut-être il est verrouillé par un autre logiciel?", Path.GetFileName(_existingFilename)),
                                        "Erreur d'enregistrement de fichier", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    _openSaveException = true;
                                }

                                if (_openSaveException == true)
                                {
                                    e.Cancel = true;
                                }
                            }

                            else if (dialogResult == DialogResult.Cancel)
                                e.Cancel = true;
                            _openSaveException = false;

                            break;
                        }


                    case "German":
                        {
                            DialogResult dialogResult = MessageBox.Show("Speichern Sie die Änderungen in " + Path.GetFileName(_existingFilename) + " vor dem Schließen?", "Schließen",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    File.WriteAllBytes(_existingFilename, Worker.Kernel);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show
                                        (String.Format("Ich kann nicht speichern Sie die Datei {0}, vielleicht ist es durch eine andere Software gesperrt?", Path.GetFileName(_existingFilename)),
                                        "Fehler beim Speichern der Datei", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    _openSaveException = true;
                                }

                                if (_openSaveException == true)
                                {
                                    e.Cancel = true;
                                }
                            }

                            else if (dialogResult == DialogResult.Cancel)
                                e.Cancel = true;
                            _openSaveException = false;

                            break;
                        }


                    case "Italian":
                        {
                            DialogResult dialogResult = MessageBox.Show("Vuoi salvare il file " + Path.GetFileName(_existingFilename) + " prima di chiudere?", "Chiudi",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    File.WriteAllBytes(_existingFilename, Worker.Kernel);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show
                                        (String.Format("Non riesco a salvare il file {0}, forse l'accesso è bloccato da un altro programma?", Path.GetFileName(_existingFilename)),
                                        "Errore durante il salvataggio del file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    _openSaveException = true;
                                }

                                if (_openSaveException == true)
                                {
                                    e.Cancel = true;
                                }
                            }

                            else if (dialogResult == DialogResult.Cancel)
                                e.Cancel = true;
                            _openSaveException = false;

                            break;
                        }


                    case "Spanish":
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Quieres guardar el archivo " + Path.GetFileName(_existingFilename) + " antes de cerrar?", "Cerca",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    File.WriteAllBytes(_existingFilename, Worker.Kernel);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show
                                        (String.Format("No puedo guardar el archivo {0}, tal vez el acceso está bloqueado por otro programa?", Path.GetFileName(_existingFilename)),
                                        "Guardar el archivo de error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    _openSaveException = true;
                                }

                                if (_openSaveException == true)
                                {
                                    e.Cancel = true;
                                }
                            }

                            else if (dialogResult == DialogResult.Cancel)
                                e.Cancel = true;
                            _openSaveException = false;

                            break;
                        }
                }
            }

            //Save current language to registry
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Siren");
            key.SetValue("Language", cbLanguages.SelectedItem.ToString());
        }

        #endregion

        #region Read values and apply them to objects

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loaded = false;
            if (Worker.Kernel == null)
                return;

            Worker.ReadItems(lbItems.SelectedIndex);
            try
            {
                numBuy.Value = Worker.GetSelectedItemsData.Price * 10;
                numSellMult.Value = Worker.GetSelectedItemsData.SellPriceMult;
                labelSellPrice.Text = Math.Round((((numBuy.Value / 10) / 2) * numSellMult.Value)).ToString() + " G";
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
            _loaded = true;
        }

        private void numBuy_ValueChanged(object sender, EventArgs e)
        {
            labelSellPrice.Text = Math.Round((((numBuy.Value / 10) / 2) * numSellMult.Value)).ToString() + " G";
        }

        private void numSellMult_ValueChanged(object sender, EventArgs e)
        {
            labelSellPrice.Text = Math.Round((((numBuy.Value / 10) / 2) * numSellMult.Value)).ToString() + " G";
        }

        #endregion
    }
}

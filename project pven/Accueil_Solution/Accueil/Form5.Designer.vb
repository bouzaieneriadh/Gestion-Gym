<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBoxPlanning = New System.Windows.Forms.GroupBox()
        Me.LabelHeureFin = New System.Windows.Forms.Label()
        Me.DateTimePickerHeureFin = New System.Windows.Forms.DateTimePicker()
        Me.LabelJour = New System.Windows.Forms.Label()
        Me.ComboBoxJour = New System.Windows.Forms.ComboBox()
        Me.LabelHeure = New System.Windows.Forms.Label()
        Me.DateTimePickerHeure = New System.Windows.Forms.DateTimePicker()
        Me.LabelActivite = New System.Windows.Forms.Label()
        Me.ComboBoxActivite = New System.Windows.Forms.ComboBox()
        Me.LabelCoach = New System.Windows.Forms.Label()
        Me.ComboBoxCoach = New System.Windows.Forms.ComboBox()
        Me.LabelSalle = New System.Windows.Forms.Label()
        Me.ComboBoxSalle = New System.Windows.Forms.ComboBox()
        Me.ButtonAjouterPlanning = New System.Windows.Forms.Button()
        Me.ButtonSupprimerPlanning = New System.Windows.Forms.Button()
        Me.DataGridViewPlanning = New System.Windows.Forms.DataGridView()
        Me.ButtonRetour = New System.Windows.Forms.Button()
        Me.GroupBoxFiltres = New System.Windows.Forms.GroupBox()
        Me.LabelFiltreJour = New System.Windows.Forms.Label()
        Me.ComboBoxFiltreJour = New System.Windows.Forms.ComboBox()
        Me.ButtonFiltrer = New System.Windows.Forms.Button()
        Me.GroupBoxPlanning.SuspendLayout()
        CType(Me.DataGridViewPlanning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxFiltres.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxPlanning
        '
        Me.GroupBoxPlanning.Controls.Add(Me.LabelHeureFin)
        Me.GroupBoxPlanning.Controls.Add(Me.DateTimePickerHeureFin)
        Me.GroupBoxPlanning.Controls.Add(Me.LabelJour)
        Me.GroupBoxPlanning.Controls.Add(Me.ComboBoxJour)
        Me.GroupBoxPlanning.Controls.Add(Me.LabelHeure)
        Me.GroupBoxPlanning.Controls.Add(Me.DateTimePickerHeure)
        Me.GroupBoxPlanning.Controls.Add(Me.LabelActivite)
        Me.GroupBoxPlanning.Controls.Add(Me.ComboBoxActivite)
        Me.GroupBoxPlanning.Controls.Add(Me.LabelCoach)
        Me.GroupBoxPlanning.Controls.Add(Me.ComboBoxCoach)
        Me.GroupBoxPlanning.Controls.Add(Me.LabelSalle)
        Me.GroupBoxPlanning.Controls.Add(Me.ComboBoxSalle)
        Me.GroupBoxPlanning.Controls.Add(Me.ButtonAjouterPlanning)
        Me.GroupBoxPlanning.Controls.Add(Me.ButtonSupprimerPlanning)
        Me.GroupBoxPlanning.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxPlanning.Name = "GroupBoxPlanning"
        Me.GroupBoxPlanning.Size = New System.Drawing.Size(760, 180)
        Me.GroupBoxPlanning.TabIndex = 0
        Me.GroupBoxPlanning.TabStop = False
        Me.GroupBoxPlanning.Text = "Ajouter/Modifier un planning"
        '
        'LabelHeureFin
        '
        Me.LabelHeureFin.AutoSize = True
        Me.LabelHeureFin.Location = New System.Drawing.Point(380, 30)
        Me.LabelHeureFin.Name = "LabelHeureFin"
        Me.LabelHeureFin.Size = New System.Drawing.Size(56, 13)
        Me.LabelHeureFin.TabIndex = 12
        Me.LabelHeureFin.Text = "Heure Fin:"
        '
        'DateTimePickerHeureFin
        '
        Me.DateTimePickerHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePickerHeureFin.Location = New System.Drawing.Point(440, 27)
        Me.DateTimePickerHeureFin.Name = "DateTimePickerHeureFin"
        Me.DateTimePickerHeureFin.ShowUpDown = True
        Me.DateTimePickerHeureFin.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerHeureFin.TabIndex = 13
        '
        'LabelJour
        '
        Me.LabelJour.AutoSize = True
        Me.LabelJour.Location = New System.Drawing.Point(20, 30)
        Me.LabelJour.Name = "LabelJour"
        Me.LabelJour.Size = New System.Drawing.Size(30, 13)
        Me.LabelJour.TabIndex = 0
        Me.LabelJour.Text = "Jour:"
        '
        'ComboBoxJour
        '
        Me.ComboBoxJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJour.FormattingEnabled = True
        Me.ComboBoxJour.Items.AddRange(New Object() {"Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"})
        Me.ComboBoxJour.Location = New System.Drawing.Point(80, 27)
        Me.ComboBoxJour.Name = "ComboBoxJour"
        Me.ComboBoxJour.Size = New System.Drawing.Size(120, 21)
        Me.ComboBoxJour.TabIndex = 1
        '
        'LabelHeure
        '
        Me.LabelHeure.AutoSize = True
        Me.LabelHeure.Location = New System.Drawing.Point(220, 30)
        Me.LabelHeure.Name = "LabelHeure"
        Me.LabelHeure.Size = New System.Drawing.Size(39, 13)
        Me.LabelHeure.TabIndex = 2
        Me.LabelHeure.Text = "Heure:"
        '
        'DateTimePickerHeure
        '
        Me.DateTimePickerHeure.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePickerHeure.Location = New System.Drawing.Point(260, 27)
        Me.DateTimePickerHeure.Name = "DateTimePickerHeure"
        Me.DateTimePickerHeure.ShowUpDown = True
        Me.DateTimePickerHeure.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePickerHeure.TabIndex = 3
        '
        'LabelActivite
        '
        Me.LabelActivite.AutoSize = True
        Me.LabelActivite.Location = New System.Drawing.Point(20, 70)
        Me.LabelActivite.Name = "LabelActivite"
        Me.LabelActivite.Size = New System.Drawing.Size(45, 13)
        Me.LabelActivite.TabIndex = 4
        Me.LabelActivite.Text = "Activité:"
        '
        'ComboBoxActivite
        '
        Me.ComboBoxActivite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxActivite.FormattingEnabled = True
        Me.ComboBoxActivite.Location = New System.Drawing.Point(80, 67)
        Me.ComboBoxActivite.Name = "ComboBoxActivite"
        Me.ComboBoxActivite.Size = New System.Drawing.Size(200, 21)
        Me.ComboBoxActivite.TabIndex = 5
        '
        'LabelCoach
        '
        Me.LabelCoach.AutoSize = True
        Me.LabelCoach.Location = New System.Drawing.Point(300, 70)
        Me.LabelCoach.Name = "LabelCoach"
        Me.LabelCoach.Size = New System.Drawing.Size(41, 13)
        Me.LabelCoach.TabIndex = 6
        Me.LabelCoach.Text = "Coach:"
        '
        'ComboBoxCoach
        '
        Me.ComboBoxCoach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCoach.FormattingEnabled = True
        Me.ComboBoxCoach.Location = New System.Drawing.Point(350, 67)
        Me.ComboBoxCoach.Name = "ComboBoxCoach"
        Me.ComboBoxCoach.Size = New System.Drawing.Size(150, 21)
        Me.ComboBoxCoach.TabIndex = 7
        '
        'LabelSalle
        '
        Me.LabelSalle.AutoSize = True
        Me.LabelSalle.Location = New System.Drawing.Point(20, 110)
        Me.LabelSalle.Name = "LabelSalle"
        Me.LabelSalle.Size = New System.Drawing.Size(33, 13)
        Me.LabelSalle.TabIndex = 8
        Me.LabelSalle.Text = "Salle:"
        '
        'ComboBoxSalle
        '
        Me.ComboBoxSalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSalle.FormattingEnabled = True
        Me.ComboBoxSalle.Items.AddRange(New Object() {"Salle A", "Salle B", "Salle C", "Salle D", "Salle E"})
        Me.ComboBoxSalle.Location = New System.Drawing.Point(80, 107)
        Me.ComboBoxSalle.Name = "ComboBoxSalle"
        Me.ComboBoxSalle.Size = New System.Drawing.Size(120, 21)
        Me.ComboBoxSalle.TabIndex = 9
        '
        'ButtonAjouterPlanning
        '
        Me.ButtonAjouterPlanning.Location = New System.Drawing.Point(540, 100)
        Me.ButtonAjouterPlanning.Name = "ButtonAjouterPlanning"
        Me.ButtonAjouterPlanning.Size = New System.Drawing.Size(100, 30)
        Me.ButtonAjouterPlanning.TabIndex = 10
        Me.ButtonAjouterPlanning.Text = "Ajouter"
        Me.ButtonAjouterPlanning.UseVisualStyleBackColor = True
        '
        'ButtonSupprimerPlanning
        '
        Me.ButtonSupprimerPlanning.Location = New System.Drawing.Point(650, 100)
        Me.ButtonSupprimerPlanning.Name = "ButtonSupprimerPlanning"
        Me.ButtonSupprimerPlanning.Size = New System.Drawing.Size(100, 30)
        Me.ButtonSupprimerPlanning.TabIndex = 11
        Me.ButtonSupprimerPlanning.Text = "Supprimer"
        Me.ButtonSupprimerPlanning.UseVisualStyleBackColor = True
        '
        'DataGridViewPlanning
        '
        Me.DataGridViewPlanning.AllowUserToAddRows = False
        Me.DataGridViewPlanning.AllowUserToDeleteRows = False
        Me.DataGridViewPlanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPlanning.Location = New System.Drawing.Point(12, 250)
        Me.DataGridViewPlanning.Name = "DataGridViewPlanning"
        Me.DataGridViewPlanning.ReadOnly = True
        Me.DataGridViewPlanning.Size = New System.Drawing.Size(760, 300)
        Me.DataGridViewPlanning.TabIndex = 1
        '
        'ButtonRetour
        '
        Me.ButtonRetour.Location = New System.Drawing.Point(12, 560)
        Me.ButtonRetour.Name = "ButtonRetour"
        Me.ButtonRetour.Size = New System.Drawing.Size(100, 30)
        Me.ButtonRetour.TabIndex = 2
        Me.ButtonRetour.Text = "Retour"
        Me.ButtonRetour.UseVisualStyleBackColor = True
        '
        'GroupBoxFiltres
        '
        Me.GroupBoxFiltres.Controls.Add(Me.LabelFiltreJour)
        Me.GroupBoxFiltres.Controls.Add(Me.ComboBoxFiltreJour)
        Me.GroupBoxFiltres.Controls.Add(Me.ButtonFiltrer)
        Me.GroupBoxFiltres.Location = New System.Drawing.Point(12, 200)
        Me.GroupBoxFiltres.Name = "GroupBoxFiltres"
        Me.GroupBoxFiltres.Size = New System.Drawing.Size(760, 70)
        Me.GroupBoxFiltres.TabIndex = 3
        Me.GroupBoxFiltres.TabStop = False
        Me.GroupBoxFiltres.Text = "Filtres"
        '
        'LabelFiltreJour
        '
        Me.LabelFiltreJour.AutoSize = True
        Me.LabelFiltreJour.Location = New System.Drawing.Point(20, 30)
        Me.LabelFiltreJour.Name = "LabelFiltreJour"
        Me.LabelFiltreJour.Size = New System.Drawing.Size(30, 13)
        Me.LabelFiltreJour.TabIndex = 0
        Me.LabelFiltreJour.Text = "Jour:"
        '
        'ComboBoxFiltreJour
        '
        Me.ComboBoxFiltreJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFiltreJour.FormattingEnabled = True
        Me.ComboBoxFiltreJour.Items.AddRange(New Object() {"Tous", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"})
        Me.ComboBoxFiltreJour.Location = New System.Drawing.Point(80, 27)
        Me.ComboBoxFiltreJour.Name = "ComboBoxFiltreJour"
        Me.ComboBoxFiltreJour.Size = New System.Drawing.Size(120, 21)
        Me.ComboBoxFiltreJour.TabIndex = 1
        '
        'ButtonFiltrer
        '
        Me.ButtonFiltrer.Location = New System.Drawing.Point(220, 25)
        Me.ButtonFiltrer.Name = "ButtonFiltrer"
        Me.ButtonFiltrer.Size = New System.Drawing.Size(100, 30)
        Me.ButtonFiltrer.TabIndex = 2
        Me.ButtonFiltrer.Text = "Filtrer"
        Me.ButtonFiltrer.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 600)
        Me.Controls.Add(Me.GroupBoxFiltres)
        Me.Controls.Add(Me.ButtonRetour)
        Me.Controls.Add(Me.DataGridViewPlanning)
        Me.Controls.Add(Me.GroupBoxPlanning)
        Me.Name = "Form5"
        Me.Text = "Gestion des Plannings"
        Me.GroupBoxPlanning.ResumeLayout(False)
        Me.GroupBoxPlanning.PerformLayout()
        CType(Me.DataGridViewPlanning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxFiltres.ResumeLayout(False)
        Me.GroupBoxFiltres.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxPlanning As System.Windows.Forms.GroupBox
    Friend WithEvents LabelHeureFin As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerHeureFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelJour As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJour As System.Windows.Forms.ComboBox
    Friend WithEvents LabelHeure As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerHeure As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelActivite As System.Windows.Forms.Label
    Friend WithEvents ComboBoxActivite As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCoach As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCoach As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSalle As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSalle As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAjouterPlanning As System.Windows.Forms.Button
    Friend WithEvents ButtonSupprimerPlanning As System.Windows.Forms.Button
    Friend WithEvents DataGridViewPlanning As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonRetour As System.Windows.Forms.Button
    Friend WithEvents GroupBoxFiltres As System.Windows.Forms.GroupBox
    Friend WithEvents LabelFiltreJour As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFiltreJour As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonFiltrer As System.Windows.Forms.Button
End Class
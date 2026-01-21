<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageCardio = New System.Windows.Forms.TabPage()
        Me.GroupBoxCardio = New System.Windows.Forms.GroupBox()
        Me.LabelCardio = New System.Windows.Forms.Label()
        Me.ComboBoxCardio = New System.Windows.Forms.ComboBox()
        Me.ButtonAjouterCardio = New System.Windows.Forms.Button()
        Me.ButtonSupprimerCardio = New System.Windows.Forms.Button()
        Me.ListBoxCardio = New System.Windows.Forms.ListBox()
        Me.TabPageRenforcement = New System.Windows.Forms.TabPage()
        Me.GroupBoxRenforcement = New System.Windows.Forms.GroupBox()
        Me.LabelRenforcement = New System.Windows.Forms.Label()
        Me.ComboBoxRenforcement = New System.Windows.Forms.ComboBox()
        Me.ButtonAjouterRenforcement = New System.Windows.Forms.Button()
        Me.ButtonSupprimerRenforcement = New System.Windows.Forms.Button()
        Me.ListBoxRenforcement = New System.Windows.Forms.ListBox()
        Me.TabPageCollectifs = New System.Windows.Forms.TabPage()
        Me.GroupBoxCollectifs = New System.Windows.Forms.GroupBox()
        Me.LabelCollectifs = New System.Windows.Forms.Label()
        Me.ComboBoxCollectifs = New System.Windows.Forms.ComboBox()
        Me.ButtonAjouterCollectifs = New System.Windows.Forms.Button()
        Me.ButtonSupprimerCollectifs = New System.Windows.Forms.Button()
        Me.ListBoxCollectifs = New System.Windows.Forms.ListBox()
        Me.ButtonRetour = New System.Windows.Forms.Button()
        Me.ButtonPlanning = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPageCardio.SuspendLayout()
        Me.GroupBoxCardio.SuspendLayout()
        Me.TabPageRenforcement.SuspendLayout()
        Me.GroupBoxRenforcement.SuspendLayout()
        Me.TabPageCollectifs.SuspendLayout()
        Me.GroupBoxCollectifs.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageCardio)
        Me.TabControl1.Controls.Add(Me.TabPageRenforcement)
        Me.TabControl1.Controls.Add(Me.TabPageCollectifs)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(760, 400)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageCardio
        '
        Me.TabPageCardio.Controls.Add(Me.GroupBoxCardio)
        Me.TabPageCardio.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCardio.Name = "TabPageCardio"
        Me.TabPageCardio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCardio.Size = New System.Drawing.Size(752, 374)
        Me.TabPageCardio.TabIndex = 0
        Me.TabPageCardio.Text = "Activités Cardio"
        Me.TabPageCardio.UseVisualStyleBackColor = True
        '
        'GroupBoxCardio
        '
        Me.GroupBoxCardio.Controls.Add(Me.LabelCardio)
        Me.GroupBoxCardio.Controls.Add(Me.ComboBoxCardio)
        Me.GroupBoxCardio.Controls.Add(Me.ButtonAjouterCardio)
        Me.GroupBoxCardio.Controls.Add(Me.ButtonSupprimerCardio)
        Me.GroupBoxCardio.Controls.Add(Me.ListBoxCardio)
        Me.GroupBoxCardio.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxCardio.Name = "GroupBoxCardio"
        Me.GroupBoxCardio.Size = New System.Drawing.Size(740, 362)
        Me.GroupBoxCardio.TabIndex = 0
        Me.GroupBoxCardio.TabStop = False
        Me.GroupBoxCardio.Text = "Gestion des activités cardio"
        '
        'LabelCardio
        '
        Me.LabelCardio.AutoSize = True
        Me.LabelCardio.Location = New System.Drawing.Point(17, 30)
        Me.LabelCardio.Name = "LabelCardio"
        Me.LabelCardio.Size = New System.Drawing.Size(101, 13)
        Me.LabelCardio.TabIndex = 0
        Me.LabelCardio.Text = "Ajouter une activité:"
        '
        'ComboBoxCardio
        '
        Me.ComboBoxCardio.FormattingEnabled = True
        Me.ComboBoxCardio.Items.AddRange(New Object() {"Vélo", "Elliptique", "Tapis de course", "Rameur", "Stepper"})
        Me.ComboBoxCardio.Location = New System.Drawing.Point(115, 27)
        Me.ComboBoxCardio.Name = "ComboBoxCardio"
        Me.ComboBoxCardio.Size = New System.Drawing.Size(150, 21)
        Me.ComboBoxCardio.TabIndex = 1
        '
        'ButtonAjouterCardio
        '
        Me.ButtonAjouterCardio.Location = New System.Drawing.Point(271, 25)
        Me.ButtonAjouterCardio.Name = "ButtonAjouterCardio"
        Me.ButtonAjouterCardio.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAjouterCardio.TabIndex = 2
        Me.ButtonAjouterCardio.Text = "Ajouter"
        Me.ButtonAjouterCardio.UseVisualStyleBackColor = True
        '
        'ButtonSupprimerCardio
        '
        Me.ButtonSupprimerCardio.Location = New System.Drawing.Point(352, 25)
        Me.ButtonSupprimerCardio.Name = "ButtonSupprimerCardio"
        Me.ButtonSupprimerCardio.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSupprimerCardio.TabIndex = 3
        Me.ButtonSupprimerCardio.Text = "Supprimer"
        Me.ButtonSupprimerCardio.UseVisualStyleBackColor = True
        '
        'ListBoxCardio
        '
        Me.ListBoxCardio.FormattingEnabled = True
        Me.ListBoxCardio.Location = New System.Drawing.Point(20, 60)
        Me.ListBoxCardio.Name = "ListBoxCardio"
        Me.ListBoxCardio.Size = New System.Drawing.Size(700, 277)
        Me.ListBoxCardio.TabIndex = 4
        '
        'TabPageRenforcement
        '
        Me.TabPageRenforcement.Controls.Add(Me.GroupBoxRenforcement)
        Me.TabPageRenforcement.Location = New System.Drawing.Point(4, 22)
        Me.TabPageRenforcement.Name = "TabPageRenforcement"
        Me.TabPageRenforcement.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRenforcement.Size = New System.Drawing.Size(752, 374)
        Me.TabPageRenforcement.TabIndex = 1
        Me.TabPageRenforcement.Text = "Renforcement Musculaire"
        Me.TabPageRenforcement.UseVisualStyleBackColor = True
        '
        'GroupBoxRenforcement
        '
        Me.GroupBoxRenforcement.Controls.Add(Me.LabelRenforcement)
        Me.GroupBoxRenforcement.Controls.Add(Me.ComboBoxRenforcement)
        Me.GroupBoxRenforcement.Controls.Add(Me.ButtonAjouterRenforcement)
        Me.GroupBoxRenforcement.Controls.Add(Me.ButtonSupprimerRenforcement)
        Me.GroupBoxRenforcement.Controls.Add(Me.ListBoxRenforcement)
        Me.GroupBoxRenforcement.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxRenforcement.Name = "GroupBoxRenforcement"
        Me.GroupBoxRenforcement.Size = New System.Drawing.Size(740, 362)
        Me.GroupBoxRenforcement.TabIndex = 0
        Me.GroupBoxRenforcement.TabStop = False
        Me.GroupBoxRenforcement.Text = "Gestion des activités de renforcement musculaire"
        '
        'LabelRenforcement
        '
        Me.LabelRenforcement.AutoSize = True
        Me.LabelRenforcement.Location = New System.Drawing.Point(17, 30)
        Me.LabelRenforcement.Name = "LabelRenforcement"
        Me.LabelRenforcement.Size = New System.Drawing.Size(101, 13)
        Me.LabelRenforcement.TabIndex = 0
        Me.LabelRenforcement.Text = "Ajouter une activité:"
        '
        'ComboBoxRenforcement
        '
        Me.ComboBoxRenforcement.FormattingEnabled = True
        Me.ComboBoxRenforcement.Items.AddRange(New Object() {"Musculation", "Gainage", "Abdominaux", "Poids libres", "Machines de musculation"})
        Me.ComboBoxRenforcement.Location = New System.Drawing.Point(115, 27)
        Me.ComboBoxRenforcement.Name = "ComboBoxRenforcement"
        Me.ComboBoxRenforcement.Size = New System.Drawing.Size(150, 21)
        Me.ComboBoxRenforcement.TabIndex = 1
        '
        'ButtonAjouterRenforcement
        '
        Me.ButtonAjouterRenforcement.Location = New System.Drawing.Point(271, 25)
        Me.ButtonAjouterRenforcement.Name = "ButtonAjouterRenforcement"
        Me.ButtonAjouterRenforcement.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAjouterRenforcement.TabIndex = 2
        Me.ButtonAjouterRenforcement.Text = "Ajouter"
        Me.ButtonAjouterRenforcement.UseVisualStyleBackColor = True
        '
        'ButtonSupprimerRenforcement
        '
        Me.ButtonSupprimerRenforcement.Location = New System.Drawing.Point(352, 25)
        Me.ButtonSupprimerRenforcement.Name = "ButtonSupprimerRenforcement"
        Me.ButtonSupprimerRenforcement.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSupprimerRenforcement.TabIndex = 3
        Me.ButtonSupprimerRenforcement.Text = "Supprimer"
        Me.ButtonSupprimerRenforcement.UseVisualStyleBackColor = True
        '
        'ListBoxRenforcement
        '
        Me.ListBoxRenforcement.FormattingEnabled = True
        Me.ListBoxRenforcement.Location = New System.Drawing.Point(20, 60)
        Me.ListBoxRenforcement.Name = "ListBoxRenforcement"
        Me.ListBoxRenforcement.Size = New System.Drawing.Size(700, 277)
        Me.ListBoxRenforcement.TabIndex = 4
        '
        'TabPageCollectifs
        '
        Me.TabPageCollectifs.Controls.Add(Me.GroupBoxCollectifs)
        Me.TabPageCollectifs.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCollectifs.Name = "TabPageCollectifs"
        Me.TabPageCollectifs.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCollectifs.Size = New System.Drawing.Size(752, 374)
        Me.TabPageCollectifs.TabIndex = 2
        Me.TabPageCollectifs.Text = "Cours Collectifs"
        Me.TabPageCollectifs.UseVisualStyleBackColor = True
        '
        'GroupBoxCollectifs
        '
        Me.GroupBoxCollectifs.Controls.Add(Me.LabelCollectifs)
        Me.GroupBoxCollectifs.Controls.Add(Me.ComboBoxCollectifs)
        Me.GroupBoxCollectifs.Controls.Add(Me.ButtonAjouterCollectifs)
        Me.GroupBoxCollectifs.Controls.Add(Me.ButtonSupprimerCollectifs)
        Me.GroupBoxCollectifs.Controls.Add(Me.ListBoxCollectifs)
        Me.GroupBoxCollectifs.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxCollectifs.Name = "GroupBoxCollectifs"
        Me.GroupBoxCollectifs.Size = New System.Drawing.Size(740, 362)
        Me.GroupBoxCollectifs.TabIndex = 0
        Me.GroupBoxCollectifs.TabStop = False
        Me.GroupBoxCollectifs.Text = "Gestion des cours collectifs"
        '
        'LabelCollectifs
        '
        Me.LabelCollectifs.AutoSize = True
        Me.LabelCollectifs.Location = New System.Drawing.Point(17, 30)
        Me.LabelCollectifs.Name = "LabelCollectifs"
        Me.LabelCollectifs.Size = New System.Drawing.Size(101, 13)
        Me.LabelCollectifs.TabIndex = 0
        Me.LabelCollectifs.Text = "Ajouter une activité:"
        '
        'ComboBoxCollectifs
        '
        Me.ComboBoxCollectifs.FormattingEnabled = True
        Me.ComboBoxCollectifs.Items.AddRange(New Object() {"Danse", "Yoga", "Pilates", "Stretching", "Aérobic", "Zumba"})
        Me.ComboBoxCollectifs.Location = New System.Drawing.Point(115, 27)
        Me.ComboBoxCollectifs.Name = "ComboBoxCollectifs"
        Me.ComboBoxCollectifs.Size = New System.Drawing.Size(150, 21)
        Me.ComboBoxCollectifs.TabIndex = 1
        '
        'ButtonAjouterCollectifs
        '
        Me.ButtonAjouterCollectifs.Location = New System.Drawing.Point(271, 25)
        Me.ButtonAjouterCollectifs.Name = "ButtonAjouterCollectifs"
        Me.ButtonAjouterCollectifs.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAjouterCollectifs.TabIndex = 2
        Me.ButtonAjouterCollectifs.Text = "Ajouter"
        Me.ButtonAjouterCollectifs.UseVisualStyleBackColor = True
        '
        'ButtonSupprimerCollectifs
        '
        Me.ButtonSupprimerCollectifs.Location = New System.Drawing.Point(352, 25)
        Me.ButtonSupprimerCollectifs.Name = "ButtonSupprimerCollectifs"
        Me.ButtonSupprimerCollectifs.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSupprimerCollectifs.TabIndex = 3
        Me.ButtonSupprimerCollectifs.Text = "Supprimer"
        Me.ButtonSupprimerCollectifs.UseVisualStyleBackColor = True
        '
        'ListBoxCollectifs
        '
        Me.ListBoxCollectifs.FormattingEnabled = True
        Me.ListBoxCollectifs.Location = New System.Drawing.Point(20, 60)
        Me.ListBoxCollectifs.Name = "ListBoxCollectifs"
        Me.ListBoxCollectifs.Size = New System.Drawing.Size(700, 277)
        Me.ListBoxCollectifs.TabIndex = 4
        '
        'ButtonRetour
        '
        Me.ButtonRetour.Location = New System.Drawing.Point(12, 425)
        Me.ButtonRetour.Name = "ButtonRetour"
        Me.ButtonRetour.Size = New System.Drawing.Size(100, 30)
        Me.ButtonRetour.TabIndex = 1
        Me.ButtonRetour.Text = "Retour"
        Me.ButtonRetour.UseVisualStyleBackColor = True
        '
        'ButtonPlanning
        '
        Me.ButtonPlanning.Location = New System.Drawing.Point(672, 425)
        Me.ButtonPlanning.Name = "ButtonPlanning"
        Me.ButtonPlanning.Size = New System.Drawing.Size(100, 30)
        Me.ButtonPlanning.TabIndex = 2
        Me.ButtonPlanning.Text = "Gérer Plannings"
        Me.ButtonPlanning.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 467)
        Me.Controls.Add(Me.ButtonPlanning)
        Me.Controls.Add(Me.ButtonRetour)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form4"
        Me.Text = "Gestion des Activités Sportives"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageCardio.ResumeLayout(False)
        Me.GroupBoxCardio.ResumeLayout(False)
        Me.GroupBoxCardio.PerformLayout()
        Me.TabPageRenforcement.ResumeLayout(False)
        Me.GroupBoxRenforcement.ResumeLayout(False)
        Me.GroupBoxRenforcement.PerformLayout()
        Me.TabPageCollectifs.ResumeLayout(False)
        Me.GroupBoxCollectifs.ResumeLayout(False)
        Me.GroupBoxCollectifs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageCardio As System.Windows.Forms.TabPage
    Friend WithEvents TabPageRenforcement As System.Windows.Forms.TabPage
    Friend WithEvents TabPageCollectifs As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxCardio As System.Windows.Forms.GroupBox
    Friend WithEvents LabelCardio As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCardio As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAjouterCardio As System.Windows.Forms.Button
    Friend WithEvents ButtonSupprimerCardio As System.Windows.Forms.Button
    Friend WithEvents ListBoxCardio As System.Windows.Forms.ListBox
    Friend WithEvents GroupBoxRenforcement As System.Windows.Forms.GroupBox
    Friend WithEvents LabelRenforcement As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRenforcement As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAjouterRenforcement As System.Windows.Forms.Button
    Friend WithEvents ButtonSupprimerRenforcement As System.Windows.Forms.Button
    Friend WithEvents ListBoxRenforcement As System.Windows.Forms.ListBox
    Friend WithEvents GroupBoxCollectifs As System.Windows.Forms.GroupBox
    Friend WithEvents LabelCollectifs As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCollectifs As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAjouterCollectifs As System.Windows.Forms.Button
    Friend WithEvents ButtonSupprimerCollectifs As System.Windows.Forms.Button
    Friend WithEvents ListBoxCollectifs As System.Windows.Forms.ListBox
    Friend WithEvents ButtonRetour As System.Windows.Forms.Button
    Friend WithEvents ButtonPlanning As System.Windows.Forms.Button
End Class
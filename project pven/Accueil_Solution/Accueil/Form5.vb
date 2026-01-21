Public Class Form5
    ' Chemin du fichier pour stocker les plannings
    Private cheminFichierPlanning As String = "C:\Users\SBS\Desktop\ai\planning.txt"
    Private cheminFichierPersonnel As String = "C:\Users\SBS\Desktop\ai\personelle.txt"
    Private cheminFichierCardio As String = "C:\Users\SBS\Desktop\ai\activites_cardio.txt"
    Private cheminFichierRenforcement As String = "C:\Users\SBS\Desktop\ai\activites_renforcement.txt"
    Private cheminFichierCollectifs As String = "C:\Users\SBS\Desktop\ai\activites_collectifs.txt"

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialiser le DataGridView avec une colonne "Heure Fin"
        DataGridViewPlanning.ColumnCount = 7
        DataGridViewPlanning.Columns(0).Name = "ID"
        DataGridViewPlanning.Columns(1).Name = "Jour"
        DataGridViewPlanning.Columns(2).Name = "Heure Début"
        DataGridViewPlanning.Columns(3).Name = "Heure Fin"
        DataGridViewPlanning.Columns(4).Name = "Activité"
        DataGridViewPlanning.Columns(5).Name = "Coach"
        DataGridViewPlanning.Columns(6).Name = "Salle"
        
        ' Masquer la colonne ID
        DataGridViewPlanning.Columns(0).Visible = False
        
        ' Charger les coaches depuis le fichier personnel
        ChargerCoaches()
        
        ' Charger les activités depuis les fichiers d'activités
        ChargerActivites()
        
        ' Charger les plannings existants
        ChargerPlannings()
        
        ' Sélectionner "Tous" dans le filtre par défaut
        ComboBoxFiltreJour.SelectedIndex = 0
    End Sub

    ' Charger les coaches depuis le fichier personnel
    Private Sub ChargerCoaches()
        ComboBoxCoach.Items.Clear()
        
        If System.IO.File.Exists(cheminFichierPersonnel) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierPersonnel)
            
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ' Format: >cin!nom&prenom$date_de_naissance;tel#poste[salairedt:
                    Dim poste As String = ligne.Split("#"c)(1).Split("["c)(0).Trim()
                    
                    ' Ajouter seulement les coaches
                    If poste.ToLower() = "coach" Then
                        Dim nomPrenom As String = ligne.Split("!"c)(1).Split("$"c)(0).Trim()
                        Dim nom As String = nomPrenom.Split("&"c)(0)
                        Dim prenom As String = nomPrenom.Split("&"c)(1)
                        
                        ComboBoxCoach.Items.Add(nom & " " & prenom)
                    End If
                End If
            Next
        End If
    End Sub

    ' Charger les activités depuis les fichiers d'activités
    Private Sub ChargerActivites()
        ComboBoxActivite.Items.Clear()
        
        ' Charger les activités cardio
        If System.IO.File.Exists(cheminFichierCardio) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierCardio)
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ComboBoxActivite.Items.Add(ligne & " (Cardio)")
                End If
            Next
        End If
        
        ' Charger les activités de renforcement
        If System.IO.File.Exists(cheminFichierRenforcement) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierRenforcement)
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ComboBoxActivite.Items.Add(ligne & " (Renforcement)")
                End If
            Next
        End If
        
        ' Charger les cours collectifs
        If System.IO.File.Exists(cheminFichierCollectifs) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierCollectifs)
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ComboBoxActivite.Items.Add(ligne & " (Collectif)")
                End If
            Next
        End If
    End Sub

    ' Charger les plannings existants avec le nouveau format
    Private Sub ChargerPlannings()
        DataGridViewPlanning.Rows.Clear()
        
        If System.IO.File.Exists(cheminFichierPlanning) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierPlanning)
            
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ' NOUVEAU FORMAT: id!jour#heureDebut|heureFin$activite&coach@salle:
                    Dim id As String = ligne.Split("!"c)(0)
                    Dim jour As String = ligne.Split("!"c)(1).Split("#"c)(0)
                    Dim temps As String = ligne.Split("#"c)(1).Split("$"c)(0)
                    Dim heureDebut As String = temps.Split("|"c)(0)
                    Dim heureFin As String = temps.Split("|"c)(1)
                    Dim activite As String = ligne.Split("$"c)(1).Split("&"c)(0)
                    Dim coach As String = ligne.Split("&"c)(1).Split("@"c)(0)
                    Dim salle As String = ligne.Split("@"c)(1).Split(":"c)(0)
                    
                    DataGridViewPlanning.Rows.Add(id, jour, heureDebut, heureFin, activite, coach, salle)
                End If
            Next
        End If
    End Sub

    ' Ajouter un planning avec la logique de chevauchement
    Private Sub ButtonAjouterPlanning_Click(sender As Object, e As EventArgs) Handles ButtonAjouterPlanning.Click
        ' Vérifier que tous les champs sont remplis
        If ComboBoxJour.SelectedIndex = -1 OrElse 
           ComboBoxActivite.SelectedIndex = -1 OrElse 
           ComboBoxCoach.SelectedIndex = -1 OrElse 
           ComboBoxSalle.SelectedIndex = -1 Then
            MessageBox.Show("Veuillez remplir tous les champs!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Récupérer les valeurs
        Dim id As String = DateTime.Now.Ticks.ToString()
        Dim jour As String = ComboBoxJour.SelectedItem.ToString()
        Dim heureDebut As TimeSpan = DateTimePickerHeure.Value.TimeOfDay
        Dim heureFin As TimeSpan = DateTimePickerHeureFin.Value.TimeOfDay
        Dim activite As String = ComboBoxActivite.SelectedItem.ToString()
        Dim coach As String = ComboBoxCoach.SelectedItem.ToString()
        Dim salle As String = ComboBoxSalle.SelectedItem.ToString()

        ' Validation : l'heure de fin doit être après l'heure de début
        If heureFin <= heureDebut Then
            MessageBox.Show("L'heure de fin doit être supérieure à l'heure de début!", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Vérifier les conflits d'horaire pour cette salle et ce jour
        For Each row As DataGridViewRow In DataGridViewPlanning.Rows
            If row.Cells("Jour").Value.ToString() = jour AndAlso 
               row.Cells("Salle").Value.ToString() = salle Then
                
                Dim existanteHeureDebut As TimeSpan = TimeSpan.Parse(row.Cells("Heure Début").Value.ToString())
                Dim existanteHeureFin As TimeSpan = TimeSpan.Parse(row.Cells("Heure Fin").Value.ToString())

                ' LOGIQUE DE CHEVAUCHEMENT :
                ' Un nouveau créneau [heureDebut, heureFin] chevauche un existant [existanteHeureDebut, existanteHeureFin]
                ' si heureDebut < existanteHeureFin ET heureFin > existanteHeureDebut
                If heureDebut < existanteHeureFin AndAlso heureFin > existanteHeureDebut Then
                    MessageBox.Show($"Ce créneau horaire est déjà occupé dans la salle {salle} de {existanteHeureDebut:hh\:mm} à {existanteHeureFin:hh\:mm}!", "Conflit d'horaire", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
        Next
        
        ' Ajouter au fichier avec le NOUVEAU FORMAT
        Using sw As New System.IO.StreamWriter(cheminFichierPlanning, True)
            sw.WriteLine($"{id}!{jour}#{heureDebut:hh\:mm}|{heureFin:hh\:mm}${activite}&{coach}@{salle}:")
        End Using
        
        ' Ajouter au DataGridView
        DataGridViewPlanning.Rows.Add(id, jour, $"{heureDebut:hh\:mm}", $"{heureFin:hh\:mm}", activite, coach, salle)
        
        MessageBox.Show("Planning ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        
        ' Réinitialiser les champs
        ComboBoxJour.SelectedIndex = -1
        ComboBoxActivite.SelectedIndex = -1
        ComboBoxCoach.SelectedIndex = -1
        ComboBoxSalle.SelectedIndex = -1
    End Sub

    ' Supprimer un planning
    Private Sub ButtonSupprimerPlanning_Click(sender As Object, e As EventArgs) Handles ButtonSupprimerPlanning.Click
        If DataGridViewPlanning.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un planning à supprimer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce planning?", 
                                                     "Confirmation", 
                                                     MessageBoxButtons.YesNo, 
                                                     MessageBoxIcon.Question)
        
        If result = DialogResult.Yes Then
            Dim idASupprimer As String = DataGridViewPlanning.SelectedRows(0).Cells("ID").Value.ToString()
            
            ' Supprimer du fichier
            Dim lignes As New List(Of String)
            If System.IO.File.Exists(cheminFichierPlanning) Then
                lignes.AddRange(System.IO.File.ReadAllLines(cheminFichierPlanning))
                
                ' Supprimer le planning de la liste
                lignes.RemoveAll(Function(line) line.StartsWith(idASupprimer & "!"))
                
                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichierPlanning, lignes.ToArray())
            End If
            
            ' Supprimer du DataGridView
            DataGridViewPlanning.Rows.RemoveAt(DataGridViewPlanning.SelectedRows(0).Index)
            
            MessageBox.Show("Planning supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Mettre à jour le filtre pour gérer le nouveau format
    Private Sub ButtonFiltrer_Click(sender As Object, e As EventArgs) Handles ButtonFiltrer.Click
        Dim jourFiltre As String = ComboBoxFiltreJour.SelectedItem.ToString()
        
        ' Si "Tous" est sélectionné, afficher tous les plannings
        If jourFiltre = "Tous" Then
            ChargerPlannings()
            Return
        End If
        
        ' Sinon, afficher seulement les plannings du jour sélectionné
        DataGridViewPlanning.Rows.Clear()
        
        If System.IO.File.Exists(cheminFichierPlanning) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierPlanning)
            
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    Dim id As String = ligne.Split("!"c)(0)
                    Dim jour As String = ligne.Split("!"c)(1).Split("#"c)(0)
                    
                    If jour = jourFiltre Then
                        Dim temps As String = ligne.Split("#"c)(1).Split("$"c)(0)
                        Dim heureDebut As String = temps.Split("|"c)(0)
                        Dim heureFin As String = temps.Split("|"c)(1)
                        Dim activite As String = ligne.Split("$"c)(1).Split("&"c)(0)
                        Dim coach As String = ligne.Split("&"c)(1).Split("@"c)(0)
                        Dim salle As String = ligne.Split("@"c)(1).Split(":"c)(0)
                        
                        DataGridViewPlanning.Rows.Add(id, jour, heureDebut, heureFin, activite, coach, salle)
                    End If
                End If
            Next
        End If
    End Sub

    ' Retour au menu principal
    Private Sub ButtonRetour_Click(sender As Object, e As EventArgs) Handles ButtonRetour.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub DateTimePickerHeure_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerHeure.ValueChanged

    End Sub

    Private Sub DateTimePickerHeureFin_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerHeureFin.ValueChanged

    End Sub

    Private Sub ComboBoxJour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxJour.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxActivite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxActivite.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxSalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSalle.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxFiltreJour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFiltreJour.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxCoach_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCoach.SelectedIndexChanged

    End Sub

    Private Sub DataGridViewPlanning_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPlanning.CellContentClick

    End Sub
End Class
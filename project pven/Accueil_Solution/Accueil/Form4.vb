Public Class Form4
    ' Chemins des fichiers pour stocker les activités
    Private cheminFichierCardio As String = "C:\Users\SBS\Desktop\project pven\activites_cardio.txt"
    Private cheminFichierRenforcement As String = "C:\Users\SBS\Desktop\project pven\activites_renforcement.txt"
    Private cheminFichierCollectifs As String = "C:\Users\SBS\Desktop\project pven\activites_collectifs.txt"

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Charger les activités existantes au démarrage
        ChargerActivitesCardio()
        ChargerActivitesRenforcement()
        ChargerActivitesCollectifs()
    End Sub

    ' Charger les activités cardio depuis le fichier
    Private Sub ChargerActivitesCardio()
        ListBoxCardio.Items.Clear()
        If System.IO.File.Exists(cheminFichierCardio) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierCardio)
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ListBoxCardio.Items.Add(ligne)
                End If
            Next
        End If
    End Sub

    ' Charger les activités de renforcement depuis le fichier
    Private Sub ChargerActivitesRenforcement()
        ListBoxRenforcement.Items.Clear()
        If System.IO.File.Exists(cheminFichierRenforcement) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierRenforcement)
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ListBoxRenforcement.Items.Add(ligne)
                End If
            Next
        End If
    End Sub

    ' Charger les cours collectifs depuis le fichier
    Private Sub ChargerActivitesCollectifs()
        ListBoxCollectifs.Items.Clear()
        If System.IO.File.Exists(cheminFichierCollectifs) Then
            Dim lignes() As String = System.IO.File.ReadAllLines(cheminFichierCollectifs)
            For Each ligne As String In lignes
                If Not String.IsNullOrWhiteSpace(ligne) Then
                    ListBoxCollectifs.Items.Add(ligne)
                End If
            Next
        End If
    End Sub

    ' Ajouter une activité cardio
    Private Sub ButtonAjouterCardio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAjouterCardio.Click
        If ComboBoxCardio.SelectedIndex <> -1 Then
            Dim nouvelleActivite As String = ComboBoxCardio.SelectedItem.ToString()

            ' Vérifier si l'activité existe déjà
            If Not ListBoxCardio.Items.Contains(nouvelleActivite) Then
                ListBoxCardio.Items.Add(nouvelleActivite)

                ' Ajouter au fichier
                Using sw As New System.IO.StreamWriter(cheminFichierCardio, True)
                    sw.WriteLine(nouvelleActivite)
                End Using

                MessageBox.Show("Activité cardio ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Cette activité existe déjà!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Veuillez sélectionner une activité!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Supprimer une activité cardio
    Private Sub ButtonSupprimerCardio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSupprimerCardio.Click
        If ListBoxCardio.SelectedIndex <> -1 Then
            Dim activiteASupprimer As String = ListBoxCardio.SelectedItem.ToString()
            ListBoxCardio.Items.RemoveAt(ListBoxCardio.SelectedIndex)

            ' Mettre à jour le fichier
            Dim lignes As New List(Of String)
            If System.IO.File.Exists(cheminFichierCardio) Then
                lignes.AddRange(System.IO.File.ReadAllLines(cheminFichierCardio))

                ' Supprimer l'activité de la liste
                lignes.RemoveAll(Function(line) line = activiteASupprimer)

                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichierCardio, lignes.ToArray())
            End If

            MessageBox.Show("Activité cardio supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Veuillez sélectionner une activité à supprimer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Ajouter une activité de renforcement
    Private Sub ButtonAjouterRenforcement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAjouterRenforcement.Click
        If ComboBoxRenforcement.SelectedIndex <> -1 Then
            Dim nouvelleActivite As String = ComboBoxRenforcement.SelectedItem.ToString()

            ' Vérifier si l'activité existe déjà
            If Not ListBoxRenforcement.Items.Contains(nouvelleActivite) Then
                ListBoxRenforcement.Items.Add(nouvelleActivite)

                ' Ajouter au fichier
                Using sw As New System.IO.StreamWriter(cheminFichierRenforcement, True)
                    sw.WriteLine(nouvelleActivite)
                End Using

                MessageBox.Show("Activité de renforcement ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Cette activité existe déjà!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Veuillez sélectionner une activité!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Supprimer une activité de renforcement
    Private Sub ButtonSupprimerRenforcement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSupprimerRenforcement.Click
        If ListBoxRenforcement.SelectedIndex <> -1 Then
            Dim activiteASupprimer As String = ListBoxRenforcement.SelectedItem.ToString()
            ListBoxRenforcement.Items.RemoveAt(ListBoxRenforcement.SelectedIndex)

            ' Mettre à jour le fichier
            Dim lignes As New List(Of String)
            If System.IO.File.Exists(cheminFichierRenforcement) Then
                lignes.AddRange(System.IO.File.ReadAllLines(cheminFichierRenforcement))

                ' Supprimer l'activité de la liste
                lignes.RemoveAll(Function(line) line = activiteASupprimer)

                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichierRenforcement, lignes.ToArray())
            End If

            MessageBox.Show("Activité de renforcement supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Veuillez sélectionner une activité à supprimer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Ajouter un cours collectif
    Private Sub ButtonAjouterCollectifs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAjouterCollectifs.Click
        If ComboBoxCollectifs.SelectedIndex <> -1 Then
            Dim nouvelleActivite As String = ComboBoxCollectifs.SelectedItem.ToString()

            ' Vérifier si l'activité existe déjà
            If Not ListBoxCollectifs.Items.Contains(nouvelleActivite) Then
                ListBoxCollectifs.Items.Add(nouvelleActivite)

                ' Ajouter au fichier
                Using sw As New System.IO.StreamWriter(cheminFichierCollectifs, True)
                    sw.WriteLine(nouvelleActivite)
                End Using

                MessageBox.Show("Cours collectif ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Ce cours existe déjà!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Veuillez sélectionner un cours!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Supprimer un cours collectif
    Private Sub ButtonSupprimerCollectifs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSupprimerCollectifs.Click
        If ListBoxCollectifs.SelectedIndex <> -1 Then
            Dim activiteASupprimer As String = ListBoxCollectifs.SelectedItem.ToString()
            ListBoxCollectifs.Items.RemoveAt(ListBoxCollectifs.SelectedIndex)

            ' Mettre à jour le fichier
            Dim lignes As New List(Of String)
            If System.IO.File.Exists(cheminFichierCollectifs) Then
                lignes.AddRange(System.IO.File.ReadAllLines(cheminFichierCollectifs))

                ' Supprimer l'activité de la liste
                lignes.RemoveAll(Function(line) line = activiteASupprimer)

                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichierCollectifs, lignes.ToArray())
            End If

            MessageBox.Show("Cours collectif supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Veuillez sélectionner un cours à supprimer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Retour au menu principal
    Private Sub ButtonRetour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRetour.Click
        Form1.Show()
        Me.Close()
    End Sub

    ' Ouvrir la form de gestion des plannings
    Private Sub ButtonPlanning_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonPlanning.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBoxCardio_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBoxCardio.Enter

    End Sub

    Private Sub GroupBoxCollectifs_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBoxCollectifs.Enter

    End Sub
End Class
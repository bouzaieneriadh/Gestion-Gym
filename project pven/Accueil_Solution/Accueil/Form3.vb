Public Class Form3
    '>cin!nom&prenom$date_de_naissance;tel#poste[salairedt:
    Function VerifierCIN(ByVal fichier As String, ByVal cin As String) As Boolean
        Dim trouve As Boolean = False

        ' Ouvrir et fermer le fichier dans la même fonction
        Using sr As New System.IO.StreamReader(fichier)
            Dim ligne As String

            Do While sr.Peek() >= 0
                ligne = sr.ReadLine()

                If ligne.StartsWith(">" & cin & "!") Then
                    trouve = True
                End If
            Loop
        End Using   ' <<< le fichier se ferme ici automatiquement

        VerifierCIN = trouve
    End Function

    Function ChercherPersonelleParCIN(ByVal cinCherche As String) As String
        Dim lignes() As String = System.IO.File.ReadAllLines("C:\Users\SBS\Desktop\project pven\personelle.txt")
        Dim ligneTrouvee As String = ""

        For i As Integer = 0 To lignes.Length - 1
            If lignes(i).Contains(">" & cinCherche & "!") Then
                ligneTrouvee = lignes(i)
            End If
        Next

        ChercherPersonelleParCIN = ligneTrouvee
    End Function

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lposte.Items.AddRange({"Manager", "Coach", "Nutritionniste", "Réceptionniste", "Technicien"})
        DataGridView1.ForeColor = Color.Black
        ChargerPersonnels()
    End Sub

    'procedure pour afficher les data dans la data grib viewer
    Private Sub ChargerPersonnels()
        ' Clear existing data
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        ' Define columns
        DataGridView1.Columns.Add("cin", "CIN")
        DataGridView1.Columns.Add("nom", "Nom")
        DataGridView1.Columns.Add("prenom", "Prénom")
        DataGridView1.Columns.Add("date_naissance", "Date de naissance")
        DataGridView1.Columns.Add("tel", "Téléphone")
        DataGridView1.Columns.Add("poste", "Poste")
        DataGridView1.Columns.Add("salaire", "Salaire")

        ' Read the file
        Dim lines() As String = System.IO.File.ReadAllLines("C:\Users\SBS\Desktop\project pven\personelle.txt")

        For Each line As String In lines
            ' Remove leading '>' if exists
            If line.StartsWith(">") Then
                line = line.Substring(1)
            End If

            ' Parse the line
            Dim cinPart As String = line.Split("!"c)(0).Replace(">", "").Trim()
            Dim nomPrenomPart As String = line.Split("!"c)(1).Split("$"c)(0).Trim()
            Dim dateNaissPart As String = line.Split("$")(1).Split(";")(0).Trim()
            Dim telPart As String = line.Split(";")(1).Split("#")(0).Trim()
            Dim postePart As String = line.Split("#")(1).Split("[")(0).Trim()
            Dim salairePart As String = line.Split("["c)(1).Split("d"c)(0).Trim()

            ' Split nom & prenom
            Dim nom As String = nomPrenomPart.Split("&")(0)
            Dim prenom As String = nomPrenomPart.Split("&")(1)

            ' Add row to DataGridView
            DataGridView1.Rows.Add(cinPart, nom, prenom, dateNaissPart, telPart, postePart, salairePart + " dt")
        Next
    End Sub


    'button retourner au meu principal
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()
    End Sub


    'Exit button pour fermer l'app
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Application.Exit()
    End Sub


    'Ajout d'un personelle
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        '>cin!nom&prenom$date_de_naissance;tel#poste[salairedt:
        Dim cin As String = Lcin.Text.Trim
        Dim nom As String = Lnom.Text.Trim
        Dim prenom As String = Lprenom.Text.Trim
        Dim date_de_naissance As Date = L_date_naiss.Value
        Dim tel As String = Ltel.Text.Trim()
        Dim salaire As String = Lsalaire.Text.Trim
        Dim valeur As Integer

        ' Calcul âge exact
        Dim age As Integer = DateTime.Now.Year - date_de_naissance.Year
        If (DateTime.Now.Month < date_de_naissance.Month) OrElse _
           (DateTime.Now.Month = date_de_naissance.Month And DateTime.Now.Day < date_de_naissance.Day) Then
            age -= 1
        End If

        If Not System.Text.RegularExpressions.Regex.IsMatch(cin, "^\d{8}$") Then
            MsgBox("CIN invalide ! (8 chiffres uniquement)")

        ElseIf VerifierCIN("C:\Users\SBS\Desktop\project pven\personelle.txt", cin) Then
            MsgBox("Adhérent existe déjà !")

        ElseIf VerifierCIN("C:\Users\SBS\Desktop\project pven\abonne.txt", cin) Then
            MsgBox("Cin exsite comme un membre !")

        ElseIf nom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(nom, "^[A-Za-z ]+$") Then
            MsgBox("Nom invalide ! (Non vide et alphabétique)")

        ElseIf prenom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(prenom, "^[A-Za-z ]+$") Then
            MsgBox("Prénom invalide ! (Non vide et alphabétique)")

        ElseIf age < 18 Then
            MsgBox("Âge invalide ! L’adhérent doit avoir au moins 18 ans.")

        ElseIf tel = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(tel, "^[952]\d{7}$") Then
            MsgBox("Téléphone invalide ! (8 chiffres, commence par 9, 5 ou 2)")

        ElseIf Lposte.SelectedIndex = -1 Then
            MsgBox("Poste Invalide")

        ElseIf Not Integer.TryParse(salaire, valeur) OrElse valeur <= 0 Then
            MsgBox("Salaire invalide ! ")

        Else
            '>cin!nom&prenom$date_de_naissance;tel#poste[salairedt:
            Dim personelle As String = ">" & cin & "!" & nom & "&" & prenom & "$" & (date_de_naissance.ToString("dd/MM/yyyy")) & ";" & tel & "#" & Lposte.SelectedItem.ToString() & "[" & salaire & "dt" & ":"
            MsgBox(personelle)
            Using sw As New System.IO.StreamWriter("C:\Users\SBS\Desktop\project pven\personelle.txt", True)
                sw.WriteLine(personelle)
            End Using
            ChargerPersonnels()
            MsgBox("avec succeess")
        End If

        'vider les cases
        cinSearch.Clear()
        Lnom.Clear()
        Lprenom.Clear()
        Lcin.Clear()
        Ltel.Clear()
        Lsalaire.Clear()
        Lposte.SelectedIndex = -1


    End Sub



    'Modifier un personelle
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cin As String = Lcin.Text.Trim
        Dim nom As String = Lnom.Text.Trim
        Dim prenom As String = Lprenom.Text.Trim
        Dim date_de_naissance As Date = L_date_naiss.Value
        Dim tel As String = Ltel.Text.Trim()
        Dim salaire As String = Lsalaire.Text.Trim
        Dim valeur As Integer


        If Not System.Text.RegularExpressions.Regex.IsMatch(cinSearch.Text().Trim(), "^\d{8}$") Then
            MsgBox("CIN a recherché est invalide ! (8 chiffres uniquement)")
        Else
            Dim ligne As String = ChercherPersonelleParCIN(cinSearch.Text().Trim())

            ' Calcul âge exact
            Dim age As Integer = DateTime.Now.Year - date_de_naissance.Year
            If (DateTime.Now.Month < date_de_naissance.Month) OrElse _
               (DateTime.Now.Month = date_de_naissance.Month And DateTime.Now.Day < date_de_naissance.Day) Then
                age -= 1
            End If

            If Not System.Text.RegularExpressions.Regex.IsMatch(cin, "^\d{8}$") Then
                MsgBox("CIN invalide ! (8 chiffres uniquement)")

            ElseIf VerifierCIN("C:\Users\SBS\Desktop\project pven\personelle.txt", cin) Then
                MsgBox("Adhérent existe déjà !")

            ElseIf VerifierCIN("C:\Users\SBS\Desktop\project pven\abonne.txt", cin) Then
                MsgBox("Cin exsite comme un membre !")

            ElseIf nom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(nom, "^[A-Za-z ]+$") Then
                MsgBox("Nom invalide ! (Non vide et alphabétique)")

            ElseIf prenom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(prenom, "^[A-Za-z ]+$") Then
                MsgBox("Prénom invalide ! (Non vide et alphabétique)")

            ElseIf age < 18 Then
                MsgBox("Âge invalide ! L’adhérent doit avoir au moins 18 ans.")

            ElseIf tel = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(tel, "^[952]\d{7}$") Then
                MsgBox("Téléphone invalide ! (8 chiffres, commence par 9, 5 ou 2)")

            ElseIf Lposte.SelectedIndex = -1 Then
                MsgBox("Poste Invalide")

            ElseIf Not Integer.TryParse(salaire, valeur) OrElse valeur <= 0 Then
                MsgBox("Salaire invalide ! ")
            Else
                MsgBox("Tous les champs sont valides ✓")
                Dim personelle As String = ">" & cin & "!" & nom & "&" & prenom & "$" & (date_de_naissance.ToString("dd/MM/yyyy")) & ";" & tel & "#" & Lposte.SelectedItem.ToString() & "[" & salaire & "dt" & ":"

                Dim lignes As New List(Of String)
                Dim cheminFichier As String = "C:\Users\SBS\Desktop\project pven\personelle.txt"

                ' Lire toutes les lignes
                If System.IO.File.Exists(cheminFichier) Then
                    lignes.AddRange(System.IO.File.ReadAllLines(cheminFichier))
                End If

                ' Chercher la ligne à modifier
                For i As Integer = 0 To lignes.Count - 1
                    Dim ligneParts As String() = lignes(i).Split("!"c)
                    If ligneParts.Length > 0 AndAlso ligneParts(0).TrimStart(">"c).Trim() = cinSearch.Text().Trim() Then
                        ' Remplacer la ligne
                        lignes(i) = personelle
                        Exit For
                    End If
                Next

                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichier, lignes.ToArray())

                MsgBox("Modification effectuée avec succès !")
                ChargerPersonnels()


            End If
        End If

        'vider les cases
        cinSearch.Clear()
        Lnom.Clear()
        Lprenom.Clear()
        Lcin.Clear()
        Ltel.Clear()
        Lsalaire.Clear()
        Lposte.SelectedIndex = -1
    End Sub


    'remplir en consultant un personelle
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cin_recherche As String = cinSearch.Text().Trim()
        If (Not System.Text.RegularExpressions.Regex.IsMatch(cin_recherche, "^\d{8}$")) Then
            MsgBox("CIN a rechercher invalide ! (8 chiffres uniquement)")
        ElseIf (Not VerifierCIN("C:\Users\SBS\Desktop\project pven\personelle.txt", cin_recherche)) Then
            MsgBox("Il n'existe pas aucun personelle avec ce Cin !")
        Else
            Dim ligne As String = ChercherPersonelleParCIN(cin_recherche)

            '>cin!nom&prenom$date_de_naissance;tel#poste[salairedt:

            ' ---- CIN ----
            Dim cin As String = ligne.Split("!"c)(0).Replace(">", "")

            ' ---- Name and Prenom ----
            Dim nom_prenom As String = (ligne.Split("!"c)(1)).Split("$"c)(0)
            Dim nom As String = nom_prenom.Split("&"c)(0)
            Dim prenom As String = nom_prenom.Split("&"c)(1)

            ' ---- Date de naissance ----
            Dim date_naissance As String = ligne.Split("$"c)(1).Split(";"c)(0)

            ' ---- Telephone ----
            Dim tel As String = ligne.Split(";"c)(1).Split("#"c)(0)

            ' ---- Poste ----
            Dim poste As String = ligne.Split("#"c)(1).Split("["c)(0)

            ' ---- Salaire ----
            Dim Salaire As String = ligne.Split("["c)(1).Split("d"c)(0)

            'MsgBox("_" & cin & "_" & nom & "_" & prenom & "_" & date_naissance & "_" & tel & "_" & poste & "_" & Salaire & "_")

            'vider les cases
            Lnom.Clear()
            Lprenom.Clear()
            Lcin.Clear()
            Ltel.Clear()
            Lsalaire.Clear()
            Lposte.SelectedIndex = -1

            'remplir les cases
            Lnom.Text = nom
            Lprenom.Text = prenom
            Lcin.Text = cin
            L_date_naiss.Value = DateTime.ParseExact(date_naissance, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            Ltel.Text = tel
            Lposte.Text = poste
            Lsalaire.Text = Salaire

        End If
    End Sub

    'Supprision d'un personelle
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (Not System.Text.RegularExpressions.Regex.IsMatch(cinSearch.Text().Trim(), "^\d{8}$")) Then
            MsgBox("CIN invalide ! (8 chiffres uniquement)")
        Else
            'les fichies 
            Dim fichierSource As String = "C:\Users\SBS\Desktop\project pven\personelle.txt"
            Dim fichierDestination As String = "C:\Users\SBS\Desktop\project pven\SupPersonelle.txt"

            If Not IO.File.Exists(fichierSource) Then
                MsgBox("Fichier personelle.txt introuvable !")
                Exit Sub
            End If

            Dim lignes As New List(Of String)
            Dim ligneSupprimee As String = ""

            ' Lire toutes les lignes
            For Each ligne As String In IO.File.ReadAllLines(fichierSource)
                If ligne.Contains(">" & cinSearch.Text().Trim() & "!") Then
                    ' Ligne trouvée → la stocker pour le fichier des supprimés
                    ligneSupprimee = ligne
                Else
                    ' Garder les autres lignes
                    lignes.Add(ligne)
                End If
            Next

            ' Si aucune ligne trouvée
            If ligneSupprimee = "" Then
                MsgBox("CIN introuvable dans le fichier.")
                Exit Sub
            End If

            ' Réécrire le fichier sans la ligne supprimée
            IO.File.WriteAllLines(fichierSource, lignes)

            ' Ajouter la ligne dans SupPersonelle.txt
            IO.File.AppendAllText(fichierDestination, ligneSupprimee & Environment.NewLine)


            MsgBox("Personnelle a été déplacé avec succès.")
            ChargerPersonnels()
        End If
        'vider les cases
        cinSearch.Clear()
        Lnom.Clear()
        Lprenom.Clear()
        Lcin.Clear()
        Ltel.Clear()
        Lsalaire.Clear()
        Lposte.SelectedIndex = -1
    End Sub


    'button pour vider les cases
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'vider les cases
        cinSearch.Clear()
        Lnom.Clear()
        Lprenom.Clear()
        Lcin.Clear()
        Ltel.Clear()
        Lsalaire.Clear()
        Lposte.SelectedIndex = -1
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
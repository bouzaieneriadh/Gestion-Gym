Public Class Form2
    ' >cin!nom&prenom$date_de_naissance;tel#adress[dateDebutTODateFin~NBmois?prixdt:

    ' fonction pour verifier l'existance de cin dans un ficher
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


    ' chercher la ligne d'un adhrent a parir dun fichier text
    Function ChercherAdherentParCIN(ByVal cinCherche As String) As String
        Dim lignes() As String = System.IO.File.ReadAllLines("C:\Users\SBS\Desktop\project pven\abonne.txt")
        Dim ligneTrouvee As String = ""

        For i As Integer = 0 To lignes.Length - 1
            If lignes(i).Contains(">" & cinCherche & "!") Then
                ligneTrouvee = lignes(i)
            End If
        Next

        ChercherAdherentParCIN = ligneTrouvee
    End Function


    'Fonction pour compter ligne de fichier (combien adherent)
    Function CompterLignes(ByVal cheminFichier As String) As Integer
        Dim compteur As Integer = 0
        If System.IO.File.Exists(cheminFichier) Then
            Using sr As New System.IO.StreamReader(cheminFichier)
                While sr.Peek() >= 0
                    sr.ReadLine()
                    compteur = compteur + 1
                End While
            End Using
        End If
        CompterLignes = compteur
    End Function


    'Modifier Adherent
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim nom As String = Lnom.Text.Trim()
        Dim prenom As String = Lprenom.Text.Trim()
        Dim date_de_naissance As Date = L_date_naiss.Value
        Dim cin As String = Lcin.Text.Trim()
        Dim adress As String = Ladress.Text.Trim()
        Dim tel As String = Ltel.Text.Trim()

        Dim mm As Integer
        Dim prix As Integer
        If (b1.Checked) Then
            mm = 1
            prix = 210
        ElseIf (b2.Checked) Then
            mm = 3
            prix = 570
        ElseIf (b3.Checked) Then
            mm = 6
            prix = 940
        ElseIf (b4.Checked) Then
            mm = 12
            prix = 1510
        End If


        If Not System.Text.RegularExpressions.Regex.IsMatch(cin_search.Text().Trim(), "^\d{8}$") Then
            MsgBox("CIN a recherché est invalide ! (8 chiffres uniquement)")

            'ElseIf (Not VerifierCIN("C:\Users\SBS\Desktop\project pven\abonne.txt", cin_search.Text().Trim())) Then
            'MsgBox("Adhérent existe déjà !")
        Else

            Dim ligne As String = ChercherAdherentParCIN(cin_search.Text().Trim())

            Dim dates As String = ligne.Split("["c)(1).Split("]"c)(0)
            Dim date_debut As String = dates.Split("T"c)(0)


            ' Calcul âge exact
            Dim age As Integer = DateTime.Now.Year - date_de_naissance.Year
            If (DateTime.Now.Month < date_de_naissance.Month) OrElse _
               (DateTime.Now.Month = date_de_naissance.Month And DateTime.Now.Day < date_de_naissance.Day) Then
                age -= 1
            End If

            'nom > prenom > age > cin > adress > tel 
            If nom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(nom, "^[A-Za-z ]+$") Then
                MsgBox("Nom invalide ! (Non vide et alphabétique)")

            ElseIf prenom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(prenom, "^[A-Za-z ]+$") Then
                MsgBox("Prénom invalide ! (Non vide et alphabétique)")

            ElseIf age < 18 Then
                MsgBox("Âge invalide ! L’adhérent doit avoir au moins 18 ans.")

            ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(cin, "^\d{8}$") Then
                MsgBox("CIN invalide ! (8 chiffres uniquement)")

            ElseIf adress = "" Then
                MsgBox("Adresse invalide ! (Ne doit pas être vide)")

            ElseIf tel = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(tel, "^[952]\d{7}$") Then
                MsgBox("Téléphone invalide ! (8 chiffres, commence par 9, 5 ou 2)")

            ElseIf (Not (b1.Checked Or b2.Checked Or b3.Checked Or b4.Checked)) Then
                MsgBox("Il faut choisir la duree de l'abonnement !")

            Else
                MsgBox("Tous les champs sont valides ✓")
                ' >cin!nom&prenom$date_de_naissance;tel#adress[dateDebutTODateFin~NBmois?prixdt:
                Dim texte As String = ">" & cin & "!" & nom & "&" & prenom & "$" & date_de_naissance.ToString("dd/MM/yyyy") & ";" & tel & "#" & adress & "[" & date_debut & "TO" & DateTime.ParseExact(date_debut, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).AddMonths(mm).ToString("dd/MM/yyyy") & "~" & mm.ToString() & "mois" & "?" & prix.ToString() & "dt" & ":"

                MsgBox(texte)
                Dim lignes As New List(Of String)
                Dim cheminFichier As String = "C:\Users\SBS\Desktop\project pven\abonne.txt"

                ' Lire toutes les lignes
                If System.IO.File.Exists(cheminFichier) Then
                    lignes.AddRange(System.IO.File.ReadAllLines(cheminFichier))
                End If

                ' Chercher la ligne à modifier
                For i As Integer = 0 To lignes.Count - 1
                    Dim ligneParts As String() = lignes(i).Split("!"c)
                    If ligneParts.Length > 0 AndAlso ligneParts(0).TrimStart(">"c).Trim() = cin_search.Text().Trim() Then
                        ' Remplacer la ligne
                        lignes(i) = texte
                        Exit For
                    End If
                Next

                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichier, lignes.ToArray())

                MsgBox("Modification effectuée avec succès !")


                'vider les cases
                Lnom.Clear()
                Lprenom.Clear()
                Lcin.Clear()
                Ladress.Clear()
                Ltel.Clear()
                cin_search.Clear()
                dtDeb.Clear()
                dtFin.Clear()
                b1.Checked = False '1mois
                b2.Checked = False '3mois
                b3.Checked = False '6mois
                b4.Checked = False '12mois

            End If
        End If
    End Sub


    'Remplir DataGridViewer
    Private Sub ChargerAbonnes()
        DataGridView1.Rows.Clear()


        Dim lignes() As String = System.IO.File.ReadAllLines("C:\Users\SBS\Desktop\project pven\abonne.txt")

        For Each ligne As String In lignes

            ' ---- CIN ----
            Dim cin As String = ligne.Split("!"c)(0).Replace(">", "")

            Dim reste As String = ligne.Split("!"c)(1)

            ' ---- NOM ----
            Dim nom As String = reste.Split("&"c)(0)

            ' ---- PRENOM ----
            Dim prenom As String = reste.Split("&"c)(1).Split("$"c)(0)

            ' ---- DATE DE NAISSANCE ----
            Dim date_naiss As String = reste.Split("$"c)(1).Split(";"c)(0)

            ' ---- TELEPHONE ----
            Dim tel As String = reste.Split(";"c)(1).Split("#"c)(0)

            ' ---- ADRESSE ----
            Dim adress As String = ligne.Split("#"c)(1).Split("["c)(0)

            ' ---- DATE DEBUT ----
            Dim date_debut As String = ligne.Split("["c)(1).Split("T"c)(0)

            ' ---- DATE FIN ----
            Dim date_fin As String = ligne.Split(New String() {"TO"}, StringSplitOptions.None)(1).Split("~"c)(0)


            ' ---- DUREE (mm mois) ----
            Dim duree As String = ligne.Split("~"c)(1).Split("?"c)(0)

            ' ---- PRIX ----
            Dim prix As String = ligne.Split("?"c)(1).Split("d"c)(0) & " dt"

            ' ---- ETAT (Actif / Expiré) ----
            Dim etat As String = ""
            If Date.Parse(date_fin) >= Date.Now Then
                etat = "Actif"
            Else
                etat = "Expiré"
            End If

            ' ---- AJOUT AU DATAGRID ----
            DataGridView1.Rows.Add(cin, nom, prenom, date_naiss, tel, adress, date_debut, date_fin, duree, prix, etat)

        Next
    End Sub



    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.ColumnCount = 11
        DataGridView1.Columns(0).Name = "CIN"
        DataGridView1.Columns(1).Name = "Nom"
        DataGridView1.Columns(2).Name = "Prenom"
        DataGridView1.Columns(3).Name = "Date de naissance"
        DataGridView1.Columns(4).Name = "Tel"
        DataGridView1.Columns(5).Name = "Adresse"
        DataGridView1.Columns(6).Name = "Date Debut"
        DataGridView1.Columns(7).Name = "Date Fin"
        DataGridView1.Columns(8).Name = "Durée"
        DataGridView1.Columns(9).Name = "Prix"
        DataGridView1.Columns(10).Name = "Etat"
        ChargerAbonnes()
    End Sub


    
    'Remplir les labels apres taper le button rechercher
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cin_recherche As String = cin_search.Text().Trim()

        If (Not System.Text.RegularExpressions.Regex.IsMatch(cin_recherche, "^\d{8}$")) Then
            MsgBox("CIN a rechercher invalide ! (8 chiffres uniquement)")
        ElseIf (Not VerifierCIN("C:\Users\SBS\Desktop\project pven\abonne.txt", cin_recherche)) Then
            MsgBox("Il n'existe pas aucun adhrent avec ce Cin !")
        Else
            MsgBox("Cin a recherchee est trouvee")
            MsgBox(ChercherAdherentParCIN(cin_recherche))

            Dim ligne As String = ChercherAdherentParCIN(cin_recherche)

            ' ---- CIN ----
            Dim cin As String = ligne.Split("!"c)(0).Replace(">", "")

            ' ---- Name and Prenom ----
            Dim nom_prenom As String = ligne.Split("!"c)(1).Split("$"c)(0)
            Dim nom As String = nom_prenom.Split("&"c)(0)
            Dim prenom As String = nom_prenom.Split("&"c)(1)

            ' ---- Date de naissance ----
            Dim date_naissance As String = ligne.Split("$"c)(1).Split(";"c)(0)

            ' ---- Telephone ----
            Dim tel As String = ligne.Split(";"c)(1).Split("#"c)(0)

            ' ---- Adresse ----
            Dim adress As String = ligne.Split("#"c)(1).Split("["c)(0)

            ' ---- Date Start & End ----
            Dim dates As String = ligne.Split("["c)(1).Split("]"c)(0)
            Dim date_debut As String = dates.Split("T"c)(0)
            Dim date_fin As String = dates.Split("O"c)(1).Split("~"c)(0)

            ' ---- Mois ----
            Dim mois As String = dates.Split("~"c)(1).Split("?"c)(0)

            ' ---- Prix ----
            Dim prix As String = ligne.Split("?"c)(1).Split(":"c)(0)

            'MsgBox("_" & nom & "_" & prenom & "_" & date_naissance & "_" & tel & "_" & adress & "_" & date_debut & "_" & date_fin & "_" & mois & "_" & prix & "_")

            '>cin!nom&prenom$date_de_naissance;tel#adress[Date.NowTODate.Now+mm]~mm mois?prixdt:


            'effasser les les cases
            Lnom.Clear()
            Lprenom.Clear()
            Lcin.Clear()
            Ladress.Clear()
            Ltel.Clear()
            dtDeb.Clear()
            dtFin.Clear()
            b1.Checked = False '1mois
            b2.Checked = False '3mois
            b3.Checked = False '6mois
            b4.Checked = False '12mois


            'remplir les donnee a leurs cases

            Lnom.Text = nom
            Lprenom.Text = prenom
            Lcin.Text = cin
            Ladress.Text = adress
            Ltel.Text = tel
            dtDeb.Text = date_debut
            dtFin.Text = date_fin
            L_date_naiss.Value = DateTime.ParseExact(date_naissance, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            If (mois = "1mois") Then
                b1.Checked = True
            ElseIf (mois = "3mois") Then
                b2.Checked = True
            ElseIf (mois = "6mois") Then
                b3.Checked = True
            ElseIf (mois = "12mois") Then
                b4.Checked = True
            End If
        End If



    End Sub

    


    'Supprimer Adherent
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If (Not System.Text.RegularExpressions.Regex.IsMatch(cin_search.Text().Trim(), "^\d{8}$")) Then
            MsgBox("CIN invalide ! (8 chiffres uniquement)")
        Else

            'les fichies 
            Dim fichierSource As String = "C:\Users\SBS\Desktop\project pven\abonne.txt"
            Dim fichierDestination As String = "C:\Users\SBS\Desktop\project pven\SupAbone.txt"


            If Not IO.File.Exists(fichierSource) Then
                MsgBox("Fichier aboonee.txt introuvable !")
                Exit Sub
            End If

            Dim lignes As New List(Of String)
            Dim ligneSupprimee As String = ""

            ' Lire toutes les lignes
            For Each ligne As String In IO.File.ReadAllLines(fichierSource)
                If ligne.Contains(">" & cin_search.Text().Trim() & "!") Then
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

            ' Ajouter la ligne dans Supabonne.txt
            IO.File.AppendAllText(fichierDestination, ligneSupprimee & Environment.NewLine)

            DataGridView1.Columns.Clear()
            DataGridView1.Rows.Clear()
            DataGridView1.ColumnCount = 11
            DataGridView1.Columns(0).Name = "CIN"
            DataGridView1.Columns(1).Name = "Nom"
            DataGridView1.Columns(2).Name = "Prenom"
            DataGridView1.Columns(3).Name = "Date de naissance"
            DataGridView1.Columns(4).Name = "Tel"
            DataGridView1.Columns(5).Name = "Adresse"
            DataGridView1.Columns(6).Name = "Date Debut"
            DataGridView1.Columns(7).Name = "Date Fin"
            DataGridView1.Columns(8).Name = "Durée"
            DataGridView1.Columns(9).Name = "Prix"
            DataGridView1.Columns(10).Name = "Etat"
            ChargerAbonnes()
            MsgBox("L'abonné a été déplacé avec succès.")
            'vider les cases
            Lnom.Clear()
            Lprenom.Clear()
            Lcin.Clear()
            Ladress.Clear()
            Ltel.Clear()
            cin_search.Clear()
            dtDeb.Clear()
            dtFin.Clear()
            b1.Checked = False '1mois
            b2.Checked = False '3mois
            b3.Checked = False '6mois
            b4.Checked = False '12mois
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()
    End Sub

    'Ajout adherent
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ' Récupération des données
        Dim nom As String = Lnom.Text.Trim()
        Dim prenom As String = Lprenom.Text.Trim()
        Dim date_de_naissance As Date = L_date_naiss.Value
        Dim cin As String = Lcin.Text.Trim()
        Dim adress As String = Ladress.Text.Trim()
        Dim tel As String = Ltel.Text.Trim()
        Dim dateAbonnement As Date = DateTime.Now 'date courrante


        ' Calcul âge exact
        Dim age As Integer = DateTime.Now.Year - date_de_naissance.Year
        If (DateTime.Now.Month < date_de_naissance.Month) OrElse _
           (DateTime.Now.Month = date_de_naissance.Month And DateTime.Now.Day < date_de_naissance.Day) Then
            age -= 1
        End If

        'nom > prenom > age > cin > adress > tel 
        If nom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(nom, "^[A-Za-z ]+$") Then
            MsgBox("Nom invalide ! (Non vide et alphabétique)")

        ElseIf prenom = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(prenom, "^[A-Za-z ]+$") Then
            MsgBox("Prénom invalide ! (Non vide et alphabétique)")

        ElseIf age < 18 Then
            MsgBox("Âge invalide ! L’adhérent doit avoir au moins 18 ans.")

        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(cin, "^\d{8}$") Then
            MsgBox("CIN invalide ! (8 chiffres uniquement)")

        ElseIf VerifierCIN("C:\Users\SBS\Desktop\project pven\abonne.txt", cin) Then
            MsgBox("Adhérent existe déjà !")

        ElseIf VerifierCIN("C:\Users\SBS\Desktop\project pven\personelle.txt", cin) Then
            MsgBox("Cin exsite comme personelle !")

        ElseIf adress = "" Then
            MsgBox("Adresse invalide ! (Ne doit pas être vide)")

        ElseIf tel = "" OrElse Not System.Text.RegularExpressions.Regex.IsMatch(tel, "^[952]\d{7}$") Then
            MsgBox("Téléphone invalide ! (8 chiffres, commence par 9, 5 ou 2)")

        ElseIf (Not (b1.Checked Or b2.Checked Or b3.Checked Or b4.Checked)) Then
            MsgBox("Il faut choisir la duree de l'abonnement !")

        Else
            MsgBox("Tous les champs sont valides ✓")

            'Dim sw As System.IO.StreamWriter = System.IO.File.AppendText("C:\Users\SBS\Desktop\project pven\abonne.txt") 'ouverture
            Dim mm As Integer
            Dim prix As Integer
            If (b1.Checked) Then
                mm = 1
                prix = 210
            ElseIf (b2.Checked) Then
                mm = 3
                prix = 570
            ElseIf (b3.Checked) Then
                mm = 6
                prix = 940
            ElseIf (b4.Checked) Then
                mm = 12
                prix = 1510
            End If


            '   >cin!nom&prenom$date_de_naissance;tel#adress[dateDebutTODateFin~NBmois?prixdt:
            Dim texte As String = ">" & cin & "!" & nom & "&" & prenom & "$" & date_de_naissance.ToString("dd/MM/yyyy") & ";" & tel & "#" & adress & "[" & Date.Now.ToString("dd/MM/yyyy") & "TO" & Date.Now.AddMonths(mm).ToString("dd/MM/yyyy") & "~" & mm.ToString() & "mois" & "?" & prix.ToString() & "dt" & ":"
            'sw.WriteLine(texte)
            'IO.File.AppendAllText("C:\Users\SBS\Desktop\project pven\abonne.txt", texte & Environment.NewLine)
            'IO.File.AppendAllText("C:\Users\SBS\Desktop\project pven\abonne.txt", texte)
            'IO.File.AppendAllText("C:\Users\SBS\Desktop\project pven\abonne.txt", texte & Environment.NewLine)

            Using sw As New System.IO.StreamWriter("C:\Users\SBS\Desktop\project pven\abonne.txt", True)
                sw.Write(texte & vbCrLf) ' vbCrLf = \r\n
            End Using
            MsgBox(texte)
            'sw.Close() 'fermeture
            'ChargerAbonnes()


            'ajout a data gribviewer
            DataGridView1.Columns.Clear()
            DataGridView1.Rows.Clear()
            DataGridView1.ColumnCount = 11
            DataGridView1.Columns(0).Name = "CIN"
            DataGridView1.Columns(1).Name = "Nom"
            DataGridView1.Columns(2).Name = "Prenom"
            DataGridView1.Columns(3).Name = "Date de naissance"
            DataGridView1.Columns(4).Name = "Tel"
            DataGridView1.Columns(5).Name = "Adresse"
            DataGridView1.Columns(6).Name = "Date Debut"
            DataGridView1.Columns(7).Name = "Date Fin"
            DataGridView1.Columns(8).Name = "Durée"
            DataGridView1.Columns(9).Name = "Prix"
            DataGridView1.Columns(10).Name = "Etat"
            ChargerAbonnes()

        End If
        'vider les cases
        Lnom.Clear()
        Lprenom.Clear()
        Lcin.Clear()
        Ladress.Clear()
        Ltel.Clear()
        cin_search.Clear()
        dtDeb.Clear()
        dtFin.Clear()
        b1.Checked = False '1mois
        b2.Checked = False '3mois
        b3.Checked = False '6mois
        b4.Checked = False '12mois
    End Sub



    'Renoulever Abonnement adherent 
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If (Not System.Text.RegularExpressions.Regex.IsMatch(cin_search.Text().Trim(), "^\d{8}$")) Then
            MsgBox("CIN a rechercher invalide ! (8 chiffres uniquement)")
        ElseIf (Not VerifierCIN("C:\Users\SBS\Desktop\project pven\abonne.txt", cin_search.Text().Trim())) Then
            MsgBox("Il n'existe pas aucun adhrent avec ce Cin !")
        Else
            MsgBox("jawekbehy")

            Dim ligne As String = ChercherAdherentParCIN(cin_search.Text().Trim())

            ' ---- End Date ----
            Dim dates As String = ligne.Split("["c)(1).Split("]"c)(0)
            Dim date_fin As String = dates.Split("O"c)(1).Split("~"c)(0)
            Dim mm As Integer
            Dim prix As Integer

            If (Date.ParseExact(date_fin, "dd/MM/yyyy", Nothing) < Date.Today) Then
                If (b1.Checked) Then
                    mm = 1
                    prix = 210
                ElseIf (b2.Checked) Then
                    mm = 3
                    prix = 570
                ElseIf (b3.Checked) Then
                    mm = 6
                    prix = 940
                ElseIf (b4.Checked) Then
                    mm = 12
                    prix = 1510
                Else
                    MsgBox("Veuillez sélectionner une durée : 1, 3, 6 ou 12 mois !")
                    Exit Sub
                End If

                'extaire les donnee
                ' ---- CIN ----
                Dim cin As String = ligne.Split("!"c)(0).Replace(">", "")

                ' ---- Name and Prenom ----
                Dim nom_prenom As String = ligne.Split("!"c)(1).Split("$"c)(0)
                Dim nom As String = nom_prenom.Split("&"c)(0)
                Dim prenom As String = nom_prenom.Split("&"c)(1)

                ' ---- Date de naissance ----
                Dim date_naissance As String = ligne.Split("$"c)(1).Split(";"c)(0)

                ' ---- Telephone ----
                Dim tel As String = ligne.Split(";"c)(1).Split("#"c)(0)

                ' ---- Adresse ----
                Dim adress As String = ligne.Split("#"c)(1).Split("["c)(0)

                Dim texte As String = ">" & cin & "!" & nom & "&" & prenom & "$" & date_naissance & ";" & tel & "#" & adress & "[" & Date.Now.ToString("dd/MM/yyyy") & "TO" & Date.Now.AddMonths(mm).ToString("dd/MM/yyyy") & "~" & mm.ToString() & "mois" & "?" & prix.ToString() & "dt" & ":"
                MsgBox(texte)

                Dim lignes As New List(Of String)
                Dim cheminFichier As String = "C:\Users\SBS\Desktop\project pven\abonne.txt"

                ' Lire toutes les lignes
                If System.IO.File.Exists(cheminFichier) Then
                    lignes.AddRange(System.IO.File.ReadAllLines(cheminFichier))
                End If

                ' Chercher la ligne à modifier
                For i As Integer = 0 To lignes.Count - 1
                    Dim ligneParts As String() = lignes(i).Split("!"c)
                    If ligneParts.Length > 0 AndAlso ligneParts(0).TrimStart(">"c).Trim() = cin_search.Text().Trim() Then
                        ' Remplacer la ligne
                        lignes(i) = texte
                        Exit For
                    End If
                Next

                ' Réécrire le fichier
                System.IO.File.WriteAllLines(cheminFichier, lignes.ToArray())

                MsgBox("Renew membership effectuée avec succès !")

            Else
                MsgBox("L'abonment de ce adherent n'est pas expiré (date fin = " & date_fin & ")")
            End If

        End If
        'vider les cases
        Lnom.Clear()
        Lprenom.Clear()
        Lcin.Clear()
        Ladress.Clear()
        Ltel.Clear()
        cin_search.Clear()
        dtDeb.Clear()
        dtFin.Clear()
        b1.Checked = False '1mois
        b2.Checked = False '3mois
        b3.Checked = False '6mois
        b4.Checked = False '12mois
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Application.Exit()
    End Sub

    
    
End Class
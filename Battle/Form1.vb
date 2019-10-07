Public Class MainForm1

    'Dim typ As Type

    Private Sub MainForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'the window accepts "drag and drop"
        Me.AllowDrop = True
    End Sub

    Private Sub MainForm1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        Me.TextBox1.Text = Me.TextBox1.Text & "Form1_DragEnter" & vbCrLf

        If CheckBox1.Checked = True Then
            e.Effect = DragDropEffects.Copy
        Else
            Me.TextBox1.Text = Me.TextBox1.Text & "DragEnter : C'est ce controle qui a déclenché l'action  " & Me.Controls.IndexOf(sender) & vbCrLf
            e.Effect = DragDropEffects.Move

            Me.TextBox1.Text = Me.TextBox1.Text & "Au départ e.X = " & e.X & vbCrLf
        End If
    End Sub

    Private Sub MainForm1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop

        Me.TextBox1.Text = Me.TextBox1.Text & "Form1_DragDrop" & vbCrLf

        If CheckBox1.Checked = True Then
            'multiplication des dragons
            Dim newDragon As New PictureBox
            newDragon.Width = 32
            newDragon.Height = 32
            newDragon.Image = e.Data.GetData(DataFormats.Bitmap)
            Controls.Add(newDragon)
            newDragon.Left = e.X - (Me.Left + 25)
            newDragon.Top = e.Y - (Me.Top + 40)
            Me.TextBox1.Text = Me.TextBox1.Text & "Multiplication de dragons" & vbCrLf
            'Ici on ajoute un évenement MouseDown et lorsqu'il survient on appelle Dragon_MouseDown
            AddHandler newDragon.MouseDown, AddressOf Dragon_MouseDown
            AddHandler newDragon.MouseHover, AddressOf Dragon_MouseHover
            Me.TextBox1.Text = Me.TextBox1.Text & "New Dragon TabIndex = " & newDragon.TabIndex & vbCrLf


        Else
            'déplacement de dragons
            'la nouvelle position du dragon est la position du curseur sur la fenêtre - la position du dragon à l'origine - la position du curseur sur la dragon à l'origine
            'Me.TextBox1.Text = Me.TextBox1.Text & "Déplacement de dragons" & vbCrLf
            Dragon.Left = e.X - (Me.Left + 25)
            Dragon.Top = e.Y - (Me.Top + 40)
            Me.TextBox1.Text = Me.TextBox1.Text & "A la fin e.X = " & e.X & vbCrLf

        End If

    End Sub

    Private Sub Dragon_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles Dragon.MouseHover

        Me.TextBox1.Text = Me.TextBox1.Text & "MouseHover " & vbCrLf
        Me.TextBox1.Text = Me.TextBox1.Text & "C'est ce controle qui a déclenché l'action  " & Me.Controls.IndexOf(sender) & vbCrLf

    End Sub


    Private Sub Dragon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Dragon.MouseDown

        If CheckBox3.Checked = True Then
            sender.dispose()

            Dim n As Integer = 0

            'ici on regarde combien d'éléments de type PictureBox il nous reste
            Dim controlPictureBox As Control
            For Each controlPictureBox In Controls
                If TypeOf controlPictureBox Is PictureBox Then
                    n = n + 1
                End If
            Next controlPictureBox

            's'il en reste 0 alors le jeu est terminé
            If n = 0 Then
                n = MsgBox("All the dragons have been killed", MsgBoxStyle.Critical, "Mission accomplished")
                'fin du programme
                End
            End If


        ElseIf CheckBox2.Checked = False Then
            'Sur l'object Dragon du type PictureBox, il y a un control sur le composant avec représentation visuelle.
            'Sur l'object control il y a une méthode qui s'appelle DoDragDrop et qui démarre une opération glisser-déplacer.
            'la méthode prend une donnée de type objet
            Me.TextBox1.Text = Me.TextBox1.Text & "DoDragDrop " & vbCrLf
            Dragon.DoDragDrop(Dragon.Image, DragDropEffects.All)
            Me.TextBox1.Text = Me.TextBox1.Text & "DoDragDrop done " & vbCrLf
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox2.Checked = False
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            'Ici on met la croix pour représenter le curseur
            Me.Cursor = Cursors.Cross
            CheckBox1.Checked = False
            CheckBox2.Checked = False
        Else
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class

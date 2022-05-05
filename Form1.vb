Public Class Form1

    Dim QuestionValidation As Boolean = False
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Validate() Then e.Cancel = True 'on empeche la fermeture si ce n'est pas validé
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.TopMost = True 'on définit la fenêtre en par dessus tout
        Me.Activate() 'on définit que la fenêtre est active
        Timer1.Enabled = True 'on démarre le timer
        Cursor.Clip = BtOui.RectangleToScreen(BtOui.ClientRectangle) 'on bloque la souris dans la case oui
    End Sub

    Private Sub Btoui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOui.Click
        Timer1.Enabled = False
        Cursor.Clip = Nothing 'on libère la souris
        QuestionValidation = True 'on autorise la fermeture
        MsgBox("Ta réponse est enregistrée, nous le savions tous que tu étais une grosse feignasse, maintenant tu l'avoues c'est encore mieux", MsgBoxStyle.Information, "Question") 'on affiche le message
        Me.Close() 'on ferme l'application
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor.Clip = BtOui.RectangleToScreen(BtOui.ClientRectangle) 'on bloque la souris dans le bouton, on le refait toutes les 250msec pour éviter qu'elle soit libérer avec un ctrl alt suppr
    End Sub

End Class

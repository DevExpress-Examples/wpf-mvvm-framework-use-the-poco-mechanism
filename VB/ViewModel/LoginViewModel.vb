Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO

Namespace Example.ViewModel

    <POCOViewModel>
    Public Class LoginViewModel

        Public Shared Function Create() As LoginViewModel
            Return ViewModelSource.Create(Function() New LoginViewModel())
        End Function

        Protected Sub New()
        End Sub

        Public Overridable Property UserName As String

        Public Sub Login()
            GetService(Of IMessageBoxService).Show("Login succeeded", "Login", MessageButton.OK, MessageIcon.Information, MessageResult.OK)
        End Sub

        Public Function CanLogin() As Boolean
            Return Not String.IsNullOrEmpty(UserName)
        End Function
    End Class
End Namespace

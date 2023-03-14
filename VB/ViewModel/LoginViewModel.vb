Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO

Namespace Example.ViewModel

    <POCOViewModel>
    Public Class LoginViewModel

        Protected Sub New()
        End Sub

        Public Shared Function Create() As LoginViewModel
            Return ViewModelSource.Create(Function() New LoginViewModel())
        End Function

        Public Overridable Property UserName As String

        Public Overridable Property [Error] As String

        Protected Overridable ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return Nothing
            End Get
        End Property

        Protected Sub OnUserNameChanged()
            RaiseCanExecuteChanged(Sub(x) x.Login())
        End Sub

        Public Sub Login()
            allowValidate = True
            Validate()
            If Not CanLogin() Then
                ShowErrorMessage()
                RaiseCanExecuteChanged(Sub(x) x.Login())
            Else
                ShowOK()
            End If
        End Sub

        Public Function CanLogin() As Boolean
            If Not allowValidate Then Return True
            Validate()
            Return String.IsNullOrEmpty([Error])
        End Function

        Private allowValidate As Boolean = False

        Private Sub Validate()
            If String.IsNullOrEmpty(UserName) Then
                [Error] = "UserName cannot be empty"
            Else
                [Error] = Nothing
            End If
        End Sub

        Private Sub ShowErrorMessage()
            If Not String.IsNullOrEmpty([Error]) Then MessageBoxService.Show([Error])
        End Sub

        Private Sub ShowOK()
            MessageBoxService.Show("OK")
        End Sub
    End Class
End Namespace

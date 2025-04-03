open System
open DrivingLicense

let testDrivingLicense() =
    printfn "Создаем тестовые водительские права..."
    
    let license1 = DrivingLicense(
        series = "12АВ",
        number = "345678",
        issueDate = DateTime(2020, 1, 15),
        expiryDate = DateTime(2030, 1, 15),
        categories = "A,B,C",
        ownerLastName = "Иванов",
        ownerFirstName = "Иван",
        ownerPatronymic = "Иванович",
        birthDate = DateTime(1985, 5, 10))
    
    let license2 = DrivingLicense(
        series = "3445",
        number = "123456",
        issueDate = DateTime(2021, 2, 20),
        expiryDate = DateTime(2031, 2, 20),
        categories = "B,D",
        ownerLastName = "Петров",
        ownerFirstName = "Петр",
        ownerPatronymic = "Петрович",
        birthDate = DateTime(1990, 7, 15))
    
    let license3 = DrivingLicense(
        series = "12АВ",
        number = "345678",
        issueDate = DateTime(2020, 1, 15),
        expiryDate = DateTime(2030, 1, 15),
        categories = "A,B,C",
        ownerLastName = "Иванов",
        ownerFirstName = "Иван",
        ownerPatronymic = "Иванович",
        birthDate = DateTime(1985, 5, 10))

    printfn "\nПрава 1:\n%O" license1
    printfn "\nПрава 2:\n%O" license2
    printfn "\nПрава 3 (копия 1):\n%O" license3

    printfn "\nСравнение:"
    printfn "Права 1 = Права 2: %b" (license1.Equals(license2))
    printfn "Права 1 = Права 3: %b" (license1.Equals(license3))

    printfn "Права 1 > Права 2: %b" (license1 > license2)
    printfn "Права 1 < Права 2: %b" (license1 < license2)

[<EntryPoint>]
let main argv =
    testDrivingLicense()
    0
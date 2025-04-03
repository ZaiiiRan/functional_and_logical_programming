module DrivingLicense
open System
open System.Text.RegularExpressions

type DrivingLicense(series: string, number: string, issueDate: DateTime, expiryDate: DateTime, 
                categories: string, ownerLastName: string, ownerFirstName: string, 
                ownerPatronymic: string, birthDate: DateTime) =
    
    let validateSeries (series: string) =
        let pattern = @"^(\d{4}|\d{2}[АВУКЕНХРОСМТ]{2})$"
        if Regex.IsMatch(series, pattern) then series
        else failwith "Неверный формат серии (должно быть 4 цифры, или 2 цифры и 2 заглавные буквы)"

    let validateNumber (number: string) =
        let pattern = @"^\d{6}$"
        if Regex.IsMatch(number, pattern) then number
        else failwith "Неверный формат номера (должно быть 6 цифр)"

    let validateCategories (categories: string) =
        let pattern = @"^[A-Z](,\s*[A-Z])*$"
        if Regex.IsMatch(categories, pattern) then categories
        else failwith "Неверный формат категорий (пример: A,B,C,D)"

    let validateName (name: string) =
        let pattern = @"^[A-ZА-Я][a-zа-яё]+$"
        if Regex.IsMatch(name, pattern) then name
        else failwith "Неверный формат имени"

    do
        if expiryDate <= issueDate then
            failwith "Дата окончания должна быть позже даты выдачи"

    member val Series = validateSeries series
    member val Number = validateNumber number
    member val IssueDate = issueDate
    member val ExpiryDate = expiryDate
    member val Categories = validateCategories categories
    member val OwnerFirstName = validateName ownerFirstName
    member val OwnerLastName = validateName ownerLastName
    member val OwnerPatronymic = validateName ownerPatronymic
    member val BirthDate = birthDate

    override this.ToString() =
        let formatDate (d: DateTime) = d.ToString("dd.MM.yyyy")
        String.concat "\n" [
            "Права на вождение:"
            $"Владелец: {this.OwnerLastName} {this.OwnerFirstName} {this.OwnerPatronymic}"
            $"Дата рождения: {formatDate this.BirthDate}"
            $"Серия/номер: {this.Series} {this.Number}"
            $"Категории: {this.Categories}"
            $"Выданы: {formatDate this.IssueDate}"
            $"Действительны до: {formatDate this.ExpiryDate}"
        ]

    interface IComparable with
        member this.CompareTo(obj) =
            match obj with
            | :? DrivingLicense as other ->
                let seriesCompare = this.Series.CompareTo(other.Series)
                if seriesCompare <> 0 then seriesCompare
                else this.Number.CompareTo(other.Number)
            | _ -> -1

    override this.Equals(obj) =
        match obj with
        | :? DrivingLicense as other ->
            this.Series = other.Series && this.Number = other.Number
        | _ -> false

    override this.GetHashCode() =
        hash (this.Series, this.Number)
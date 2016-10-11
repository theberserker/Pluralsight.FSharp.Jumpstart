module Module4_OptionTypes

(* Option Types
   - OptionTypes is an explicit way of saying that we might have a valiue for some item, or we might not

*)

type Company = {
    Name: string
    TaxNo: int option // option will tell that value might not be present;
}

let company1 = { Name="Spilak Evil Corp"; TaxNo=None }
let comapny2 = { Name="Spilak Good Corp"; TaxNo=Some 123 } // note that we have to add Some, because it expects type "int option" and not only "int".

let PrintCompany(company: Company) = 
    let taxNrString = 
        match company.TaxNo with 
        | Some n -> sprintf " [%i]" n
        | None -> ""

    printfn "%s%s" company.Name taxNrString

// this is equal to above code, but if-else is considered an antipattern; above match approach is more isiomatic and pays off in larger codebases & compex scenarios
let PrintCompanyAntipattern(company: Company) = 
    let taxNrString = 
        if company.TaxNo.IsSome then
            sprintf " [%i]" company.TaxNo.Value
        else
            ""
    printfn "%s%s" company.Name taxNrString
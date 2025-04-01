export class Loanhistory {
    loanId?:number
    status?:string
    loanAmount?:number
    amountPaid?:number
    remainingBalance?:number
    dueDate?:Date

    constructor(loanId:number, status:string, loanAmount:number, amoutPaid:number, remainingBalance:number, dueDate:Date)
    {
        this.loanId=loanId,
        this.status=status,
        this.loanAmount=loanAmount,
        this.amountPaid=amoutPaid,
        this.remainingBalance=remainingBalance,
        this.dueDate=dueDate
    }
    
      
}

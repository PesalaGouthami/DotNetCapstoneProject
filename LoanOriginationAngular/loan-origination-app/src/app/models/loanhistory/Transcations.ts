export class Transactions {
        
    TransactionId: number;
    amountPaid: number;
    Date?: Date;

    constructor(TransactionId:number,amountPaid:number,Date:Date){
        this.TransactionId=TransactionId,
        this.amountPaid=amountPaid
        this.Date=Date
    }
      
}

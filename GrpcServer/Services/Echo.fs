module Services 

open System.Threading.Tasks
open Grpc.Core
open Protos

type Echo() =
    inherit Messaging.MessagingBase()
    
    override this.Send(message: Message, ctx: ServerCallContext) =
            let sender, content = message.Sender, message.Content
            
            printfn "received from %s : %s" sender content
             
            Response(Status = Status.Ok, Message = content) |> Task.FromResult 
            
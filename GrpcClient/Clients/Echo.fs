module Clients

open System
open Protos

type Echo(senderName: string, channel: Grpc.Core.Channel) =
    inherit Messaging.MessagingClient(channel)
    
    member private this.Id = senderName
    
    member this.Start() =
        let mutable keepGoing = true
        while keepGoing do
            printfn "Insert a message..."
            let content = Console.ReadLine()
            let message = Message(Sender = this.Id, Content = content)
            let response = this.Send(message)
            let status, message = response.Status, response.Message
            printfn "Server Responded: %s" message
            keepGoing <- Status.Ok = status && not (message = "close")
        printfn "shutting client down..."
        0


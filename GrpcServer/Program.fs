module GrpcServer

open Grpc.Core
open Services
open Protos
open Services
open System

let echoService = Messaging.BindService(Echo())

[<EntryPoint>]
let main _ =
    let server = Server()
    server.Ports.Add("localhost", 8080, ServerCredentials.Insecure) |> ignore
    server.Services.Add(echoService)
    server.Start()
    printfn "Server running on localhost:8080 press 'Enter' to stop..."
    Console.Read() |> ignore
    0 

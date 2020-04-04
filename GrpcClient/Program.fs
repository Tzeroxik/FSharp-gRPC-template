module GrpcClient

open Grpc.Core
open Clients

[<EntryPoint>]
let main _ =
    Channel("localhost:8080", ChannelCredentials.Insecure)
    |> fun channel -> Echo("me", channel).Start()
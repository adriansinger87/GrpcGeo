# GrpcGeo
> A gRPC Demo for .NET with a client and a server app.

## Introduction

This demo shows the basic principles of [gRPC](https://grpc.io/).
The **gRPC client** calls the server and sends its IP address.
The **gRPC server** provides geo information like country, city longitude and latitude for a given IP address.

### Remote Procedure Calls with G!

The system was initiated by Google and is now driven by a larger community,
so the best start is to visit the [website](https://grpc.io/).
GRPC is an efficient language neutral framework to connect applications, based on [HTTP/2](https://http2.github.io/) and [Protocol Buffers](https://developers.google.com/protocol-buffers/), alias protobuf.

### Assemblies
* **GrpcGeo.Domain** - contains the protobuf file a d compiles the classes for the gRPC client and server.
* **GrpcGeo.Client** - .NET Core console app that connects to a gRPC server on the localhost.
* **GrpcGeo.Server** - .NET Core console app that provides a service that needs the IP address and returns the geo information. 

---
###### Have a nice day!

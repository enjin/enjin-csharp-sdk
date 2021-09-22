# Blockchain SDK by Enjin for C#

Create blockchain video games and applications using the C# programming language.

[Learn more](https://enjin.io/) about the Enjin blockchain platform.

Sign up to Enjin Cloud: [Kovan (Testnet)](https://kovan.cloud.enjin.io/),
[Mainnet (Production)](https://cloud.enjin.io/) or [JumpNet](https://jumpnet.cloud.enjin.io/).

### Resources

* [Enjin Docs](https://enjin.io/docs)

### Table of Contents
* [Compatibility](#compatibility)
* [Quick Start](#quick-start)
* [Contributing](#contributing)
  * [Issues](#issues)
  * [Pull Requests](#pull-requests)

## Compatibility

The Enjin C# SDK utilizes the .NET 2.0 Standard Library.

## Quick Start

This example showcases how to quickly create and authenticate a client on the project schema which will then allow us to
make further requests to the platform.

```c#
using System;
using Enjin.SDK;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;

public static class Program
{
    public static void Main()
    {
        ProjectClient client = new ProjectClient(EnjinHosts.KOVAN);

        AuthProject req = new AuthProject()
            .Uuid("<the-project's-uuid>")
            .Secret("<the-project's-secret>");

        GraphqlResponse<AccessToken> res = client.AuthProject(req).Result;

        if (!res.IsSuccess)
        {
            Console.Out.WriteLine("AuthProject request failed");
            client.Dispose();
            return;
        }

        client.Auth(res.Result.Token);

        if (client.IsAuthenticated)
        {
            Console.Out.WriteLine("Client is now authenticated");
        }
        else
        {
            Console.Out.WriteLine("Client was not authenticated");
        }

        client.Dispose();
    }
}
```

## Contributing

Contributions to the SDK are appreciated!

### Issues

You can open issues for bugs and enhancement requests.

### Pull Requests

If you make any changes or improvements to the SDK, which you believe are beneficial to others, consider making a pull
request to merge your changes to be included in the next release.

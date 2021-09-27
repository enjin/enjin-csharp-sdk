# Blockchain SDK by Enjin for C#

Create blockchain video games and applications using the C# programming language.

[Learn more](https://enjin.io/) about the Enjin blockchain platform.

Sign up to Enjin Cloud: [Kovan (Testnet)](https://kovan.cloud.enjin.io/),
[Mainnet (Production)](https://cloud.enjin.io/) or [JumpNet](https://jumpnet.cloud.enjin.io/).

### Resources

* [Enjin Docs](https://docs.enjin.io)

### Table of Contents
* [Compatibility](#compatibility)
* [Quick Start](#quick-start)
* [Contributing](#contributing)
  * [Issues](#issues)
  * [Pull Requests](#pull-requests)
* [Copyright and Licensing](#copyright-and-licensing)

## Compatibility

The Enjin C# SDK is targeted for .NET Standard 2.0.

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
        // Builds the project client to run on the Kovan test network.
        // See: https://kovan.cloud.enjin.io to sign up for the test network.
        ProjectClient client = new ProjectClient(EnjinHosts.KOVAN);

        // Creates the request to authenticate the client.
        // Replace the appropriate strings with the project's UUID and secret.
        AuthProject req = new AuthProject()
            .Uuid("<the-project's-uuid>")
            .Secret("<the-project's-secret>");

        // Sends the request to the platform and gets the response.
        GraphqlResponse<AccessToken> res = client.AuthProject(req).Result;

        // Checks if the request was successful.
        if (!res.IsSuccess)
        {
            Console.Out.WriteLine("AuthProject request failed");
            client.Dispose();
            return;
        }

        // Authenticates the client with the access token in the response.
        client.Auth(res.Result.Token);

        // Checks if the client was authenticated.
        if (client.IsAuthenticated)
        {
            Console.Out.WriteLine("Client is now authenticated");
        }
        else
        {
            Console.Out.WriteLine("Client was not authenticated");
        }

        // Dispose client as part of cleanup and free any resources.
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

Ensure that tests are passing when running `TestSuite` and add any necessary test classes or test cases for your code.

Be sure to include your name in the list of contributors.

## Copyright and Licensing

The license summary below may be copied.

```
Copyright 2021 Enjin Pte. Ltd.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```

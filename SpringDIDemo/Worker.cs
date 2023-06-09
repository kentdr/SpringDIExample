﻿using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDIDemo
{
  class Worker : BackgroundService
  {
    private readonly IMessageSession messageSession;

    public Worker(IMessageSession messageSession)
    {
      this.messageSession = messageSession;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
      try
      {
        var number = 0;
        while (!cancellationToken.IsCancellationRequested)
        {
          await messageSession.SendLocal(new MyMessage { Number = number++ }, cancellationToken)
              .ConfigureAwait(false);

          await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
        }
      }
      catch (OperationCanceledException)
      {
        // graceful shutdown
      }
    }
  }
}

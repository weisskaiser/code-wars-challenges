﻿using System.Collections.Generic;

namespace CodeWars.Challenges4Kyu.ASimplisticTcpFiniteStateMachine
{
    public class TCP
    {
        static IDictionary<string, IDictionary<string, string>> transitionTable = new Dictionary<string, IDictionary<string, string>>()
        {
            ["CLOSED"] = new Dictionary<string, string>
            {
                ["APP_PASSIVE_OPEN"] = "LISTEN",
                ["APP_ACTIVE_OPEN"] = "SYN_SENT",
            },
            ["LISTEN"] = new Dictionary<string, string>
            {
                ["RCV_SYN"] = "SYN_RCVD",
                ["APP_SEND"] = "SYN_SENT",
                ["APP_CLOSE"] = "CLOSED",
            },
            ["SYN_RCVD"] = new Dictionary<string, string>
            {
                ["APP_CLOSE"] = "FIN_WAIT_1",
                ["RCV_ACK"] = "ESTABLISHED",
            },
            ["SYN_SENT"] = new Dictionary<string, string>
            {
                ["RCV_SYN"] = "SYN_RCVD",
                ["RCV_SYN_ACK"] = "ESTABLISHED",
                ["APP_CLOSE"] = "CLOSED",
            },
            ["ESTABLISHED"] = new Dictionary<string, string>
            {
                ["APP_CLOSE"] = "FIN_WAIT_1",
                ["RCV_FIN"] = "CLOSE_WAIT",
            },
            ["FIN_WAIT_1"] = new Dictionary<string, string>
            {
                ["RCV_FIN"] = "CLOSING",
                ["RCV_FIN_ACK"] = "TIME_WAIT",
                ["RCV_ACK"] = "FIN_WAIT_2",
            },
            ["CLOSING"] = new Dictionary<string, string>
            {
                ["RCV_ACK"] = "TIME_WAIT",
            },
            ["FIN_WAIT_2"] = new Dictionary<string, string>
            {
                ["RCV_FIN"] = "TIME_WAIT",
            },
            ["TIME_WAIT"] = new Dictionary<string, string>
            {
                ["APP_TIMEOUT"] = "CLOSED",
            },
            ["CLOSE_WAIT"] = new Dictionary<string, string>
            {
                ["APP_CLOSE"] = "LAST_ACK",
            },
            ["LAST_ACK"] = new Dictionary<string, string>
            {
                ["RCV_ACK"] = "CLOSED",
            }
        };

        public static string TraverseStates(string[] events)
        {
            var state = "CLOSED"; // initial state, always
                                  // Your code here!
            foreach (var @event in events)
            {
                if (transitionTable[state].ContainsKey(@event))
                {
                    state = transitionTable[state][@event];
                }
                else
                {
                    state = "ERROR";
                    break;
                }
            }

            return state;
        }
    }
}

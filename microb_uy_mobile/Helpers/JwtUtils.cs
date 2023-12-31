﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.RegularExpressions;

public static class JwtUtils
{
    public static IDictionary<string, object> DecodeJwtToken(string token)
    {
        var parts = token.Split('.');
        if (parts.Length != 3)
        {
            throw new ArgumentException("El token JWT no tiene el formato esperado.");
        }

        var payload = parts[1];
        var payloadJson = Base64UrlDecode(payload);
        using var document = JsonDocument.Parse(payloadJson);
        var payloadDict = new Dictionary<string, object>();

        foreach (var element in document.RootElement.EnumerateObject())
        {
            payloadDict.Add(element.Name, element.Value.ToString());
        }

        return payloadDict;
    }

    private static string Base64UrlDecode(string input)
    {
        var output = input;
        output = output.Replace('-', '+'); // 62nd char of encoding
        output = output.Replace('_', '/'); // 63rd char of encoding
        switch (output.Length % 4) // Pad with trailing '='s
        {
            case 0: break; // No pad chars in this case
            case 2: output += "=="; break; // Two pad chars
            case 3: output += "="; break; // One pad char
            default: throw new ArgumentException("String ilegal de base64url en entrada.");
        }
        var converted = Convert.FromBase64String(output); // Standard base64 decoder
        return System.Text.Encoding.UTF8.GetString(converted);
    }
}

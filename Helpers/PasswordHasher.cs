﻿using System;
using System.Security.Cryptography;

namespace ScheduleOneInventoryManager.Helpers;

public class PasswordHasher
{

    public static bool VerifyPassword(string password, string storedHash)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        for (int i = 0; i < 32; i++)

        {
            if (hashBytes[i + 16] != hash[i]) return false;
        }
        return true;
    }
}
﻿using AdminApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;

namespace AdminApp.Controller {
    public class Controller {

        private static Random rng = new Random();

        public static Subject CreateSubject(string name) {
            return null;
        }

        public static bool SubjectExists(string name) {
            return true;
        }

        public static bool IsSubjectValid(string name) {
            return true;
        }

        public static AbstractUser CreateUser(string name, string email, UserType userType) {
            // return null if operation fails
            // client code must check if result is null
            return null;
        }

        public static bool DeleteUser(AbstractUser user) {
            // if last admin, don't delete else, remove from DB
            // if student has testforms, only set IsNotRemoved = false, else delete from DB
            // if teacher has testdefinitions, only set IsNotRemoved = false, else delete from DB
            return true;
        }

        public static string ResetPassword(AbstractUser user) {
            return null;
        }

        public static string GenerateNewPassword() {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rng.Next(chars.Length)];
        
            }

            var password = new string(stringChars);
            return password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Context;

namespace Testverktyg {
    public static class MockData {
        private static void DeleteAndRecreate() {
            using (var db = new TestverktygContext()) {
                db.Database.Delete();
                db.Database.CreateIfNotExists();
            }
        }

        private static void Seed() {
            using (var db = new TestverktygContext()) {
                // TODO: you know what to do... (>_>) (<_<) ... I know...
            }
        }

        public static void Reset() {
            DeleteAndRecreate();
            Seed();
        }
    }
}

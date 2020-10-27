using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace SecurePassWordXMLStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Salt { get; set; }
        public string HashedPass { get; set; }
    }
}

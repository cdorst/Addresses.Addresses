// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using Addresses.StateCityZips;
using Addresses.StreetAddresses;
using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.Addresses
{
    /// <summary>Contains US addresses</summary>
    [ProtoBufSerializable]
    [Table("Addresses", Schema = "Addresses")]
    public class Address : IStaticEntity<Address, int>
    {
        public Address()
        {
        }

        public Address(StateCityZip stateCityZip, StreetAddress streetAddress)
        {
            StateCityZip = stateCityZip;
            StreetAddress = streetAddress;
        }

        /// <summary>Address unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int AddressId { get; set; }

        /// <summary>Contains StateCityZip reference</summary>
        [Position(3)]
        public StateCityZip StateCityZip { get; set; }

        /// <summary>Contains StateCityZip foreign key</summary>
        [Position(2)]
        public int StateCityZipId { get; set; }

        /// <summary>Contains StreetAddress reference</summary>
        [Position(5)]
        public StreetAddress StreetAddress { get; set; }

        /// <summary>Contains StreetAddress foreign key</summary>
        [Position(4)]
        public int StreetAddressId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 11;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => AddressId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<Address, object>> GetUniqueIndex() => entity => new { entity.StateCityZipId, entity.StreetAddressId };
    }
}

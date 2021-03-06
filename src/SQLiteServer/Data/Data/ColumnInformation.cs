﻿//This file is part of SQLiteServer.
//
//    SQLiteServer is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    SQLiteServer is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with SQLiteServer.  If not, see<https://www.gnu.org/licenses/gpl-3.0.en.html>.

using System;
using SQLiteServer.Fields;

namespace SQLiteServer.Data.Data
{
  internal class ColumnInformation
  {
    /// <summary>
    /// The column name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The ordinal value.
    /// </summary>
    public int Ordinal { get; }

    /// <summary>
    /// If the data is null or not
    /// </summary>
    public bool IsNull { get; }

    /// <summary>
    /// The column field.
    /// </summary>
    public Field Field { get; }

    /// <summary>
    /// Get a filed value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Get<T>()
    {
      return Field.Get<T>();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="field"></param>
    /// <param name="ordinal"></param>
    /// <param name="name"></param>
    /// <param name="isNull"></param>
    public ColumnInformation(Field field, int ordinal, string name, bool isNull )
    {
      if (null == field)
      {
        throw new ArgumentNullException( nameof(field));
      }
      Field = field;

      if (string.IsNullOrWhiteSpace(name))
      {
        throw new ArgumentException("The name cannot be empty or null");
      }
      Name = name;

      if (ordinal < 0)
      {
        throw new ArgumentException("The ordinal cannot be negative or zero.");
      }
      Ordinal = ordinal;
      IsNull = isNull;
    }
  }
}

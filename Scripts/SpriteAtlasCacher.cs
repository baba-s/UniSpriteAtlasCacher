using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;
using Object = UnityEngine.Object;

namespace UniSpriteAtlasCacher
{
	[Serializable]
	public class SpriteAtlasCacher : IDisposable
	{
		[SerializeField] private SpriteAtlas m_spriteAtlas = default;

		private readonly Dictionary<string, Sprite> m_table = new Dictionary<string, Sprite>();

		public ICollection<KeyValuePair<string, Sprite>> Table         => m_table;
		public IReadOnlyCollection<string>               CachedNames   => m_table.Keys;
		public IReadOnlyCollection<Sprite>               CachedSprites => m_table.Values;

		public Sprite GetSprite( string name )
		{
			if ( m_spriteAtlas == null ) return null;

			if ( m_table.TryGetValue( name, out var sprite ) ) return sprite;

			sprite = m_spriteAtlas.GetSprite( name );
			m_table.Add( name, sprite );
			return sprite;
		}

		public void CacheAll()
		{
			var sprites = new Sprite[m_spriteAtlas.spriteCount];
			m_spriteAtlas.GetSprites( sprites );

			m_table.Clear();

			for ( var i = 0; i < sprites.Length; i++ )
			{
				var sprite = sprites[ i ];
				var name   = sprite.name;

				name = name.Remove( name.Length - 7, 7 );

				m_table.Add( name, sprite );
			}
		}

		public void Dispose()
		{
			if ( m_spriteAtlas == null ) return;
			if ( m_table.Count <= 0 ) return;

			var sprites = m_table.Values.Where( sprite => sprite != null );

			foreach ( var sprite in sprites )
			{
				Object.Destroy( sprite );
			}

			m_table.Clear();
		}
	}
}
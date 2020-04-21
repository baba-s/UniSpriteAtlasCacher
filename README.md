# Uni Sprite Atlas Cacher

SpriteAtlas.GetSprite したスプライトをキャッシュするクラス

## 使用例

```cs
using UniSpriteAtlasCacher;
using UnityEngine;

public class Example : MonoBehaviour
{
    public SpriteAtlasCacher m_cacher;

    private void Start()
    {
        // 指定されたスプライトを SpriteAtlas.GetSprite して内部でキャッシュする
        var sprite = m_cacher.GetSprite( "【スプライト名】" );

        // SpriteAtlas に含まれているすべてのスプライトをキャッシュする
        m_cacher.CacheAll();

        // キャッシュされているすべてのスプライトの情報を取得する
        foreach ( var n in m_cacher.Table )
        {
            Debug.Log( n.Key + ":" + n.Value.name );
        }
        
        // キャッシュされているすべてのスプライトの名前を取得する
        foreach ( var n in m_cacher.CachedNames )
        {
            Debug.Log( n );
        }
        
        // キャッシュされているすべてのスプライトを取得する
        foreach ( var n in m_cacher.CachedSprites )
        {
            Debug.Log( n.name );
        }
    }

    private void OnDestroy()
    {
        // SpriteAtlas.GetSprite したすべてのスプライトを破棄する
        m_cacher.Dispose();
    }
}
```

![2020-04-21_223744](https://user-images.githubusercontent.com/6134875/79872556-e68c5d80-8420-11ea-9a86-f1e971ef6d95.png)

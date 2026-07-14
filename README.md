# 約20秒の短尺3Dキャラクター演出

![thumbnail](./Images/thumbnail.png)

## 概要

Unityで制作した、短尺の3Dキャラクター演出ポートフォリオです。  
キャラクターアニメーション、カメラ、ライティング、エフェクト、サウンドを統合し、約20秒の演出シーンとして構成しています。

本作品では、3Dキャラクター表現とUnity上での演出制御を組み合わせ、短い時間で作品の雰囲気・動き・見せ場が伝わることを目指しました。

## デモ動画

[作品デモ動画](./Videos/demo.mp4)

## 特徴

- Unity上での3Dキャラクター演出シーン構築
- Blenderで作成したアニメーションのUnity連携
- lilToonを使用したアニメ風の質感表現
- ライティング、エフェクト、サウンドによる演出調整
- C#スクリプトによる一部演出制御

## リポジトリ構成

```txt
unity-3d-portfolio/
├─ Docs/
│  ├─ Credits.md
│  └─ TechnicalNote.md
├─ Images/
│  └─ thumbnail.png
├─ Scripts/
│  └─ ScreenFadeInController.cs
│  └─ ScreenFadeOutController.cs
│  └─ VictoryTimelineController.cs
├─ Videos/
│  └─ demo.mp4
└─ README.md
```

## 関連資料

- [技術資料](./Docs/TechnicalNote.md)
- [使用素材・クレジット](./Docs/Credits.md)

## ソースコード

本リポジトリでは、作品内で使用した自作C#スクリプトを `Scripts/` 配下に掲載しています。

## 注意事項

本作品では再配布不可の有料アセットを使用しているため、Unityプロジェクト本体は公開していません。  
代わりに、デモ動画、技術資料、使用素材一覧、自作スクリプトを掲載しています。

面接時には、ローカル環境上でUnityプロジェクトの構成をお見せすることが可能です。

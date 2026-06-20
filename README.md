This is a project i developed to test static & dynamic lighting, environment design, interior design, terrain and URP in Unity.

I created a city using assets such as road, grass path, sidewalks, buildings, street lights, vendors, car parks.
I used a naming convention for prefabs such as "floor_grassPath2", "building_apartmentBuilding10", "floor_roadWithLineDashed_16m".

# Environment Design & Lighting Test Project
A 3D sandbox environment designed to test static & dynamic lighting setup, environmental modular layout, terrain structures, and Universal Render Pipeline (URP) optimization in Unity. 

The project features multiple experimental scenes, separating First-Person Perspective (FPS) and Third-Person Perspective (TPS) systems across individual scenes, alongside integrated Day-Night cycles and clean prefab structural organization.

---

## 🚀 Quick Start

Want to skip the code and explore the environment? 

1. **[Download the Repository](https://github.com/Frext/CofiShopTycoon-repo/archive/refs/heads/main.zip)**

3. Extract the ZIP file.

4. For **outdoor** environment which uses **Third-Person Perspective (TPS)**, open the **`BuildWindows/City`** folder and run the game executable named **`Cofi Shop Tycoon.exe`**.

6. For **indoor** environment which uses **First-Person Perspective (FPS)**, open the **`BuildWindows/CofiShop`** folder and run the game executable named **`Cofi Shop Tycoon.exe`**.

---

## 🎮 Controls

| Key | Action |
| :---: | :--- |
| **W A S D** | Move |
| **SPACE** | Jump |
| **MOUSE** | Look Around |

---

## 📸 Screenshots

| Daytime Aerial Overview | Nighttime Aerial Overview |
|:---:|:---:|
| <img src="Screenshot 2026-06-20 114607.png" width="100%" alt="Daytime Aerial Overview"/> | <img src="Screenshot 2026-06-20 115401.png" width="100%" alt="Nighttime Aerial Overview"/> |

| Central Residential Grid (Day) | Central Residential Grid (Night) |
|:---:|:---:|
| <img src="Screenshot 2026-06-20 114838.jpg" width="100%" alt="Central Residential Grid Day"/> | <img src="Screenshot 2026-06-20 115325.jpg" width="100%" alt="Central Residential Grid Night"/> |

| Main Street View (Day) | Main Street View (Night) |
|:---:|:---:|
| <img src="Screenshot 2026-06-20 114930.jpg" width="100%" alt="Main Street View Day"/> | <img src="Screenshot 2026-06-20 115313.jpg" width="100%" alt="Main Street View Night"/> |

| Central Park Pathway (Night) | Third-Person Controller Intersection Scene |
|:---:|:---:|
| <img src="Screenshot 2026-06-20 115239.jpg" width="100%" alt="Central Park Pathway"/> | <img src="Screenshot 2026-06-20 115535.png" width="100%" alt="Third-Person Controller Intersection Scene"/> |

---

## 🛠️ Project Core Systems

- **Static & Dynamic Lighting:** Fully baked lightmaps for buildings and static environmental floors alongside dynamic Realtime shadows for streetlamps, traffic signals, and moving entities under a modular sky box.
- **URP Optimization:** Leverages Universal Render Pipeline settings including optimized Render Features, Ambient Occlusion, and post-processing profiles suited for seamless transitions.
- **Scene-Based Architecture:** Perspectives are built into separate design matrices:
  - **FPS Scene:** First-Person exploration focusing on detailed ground-level ambient structures.
  - **TPS Scene:** Third-Person structural layout featuring Cinemachine integration around a tracking capsule entity.
- **Day-Night Cycle:** Implemented continuous directional light rotation synced with skybox material parameter blends and real-time emission mapping on building windows and street fixtures.
- **Modular Asset Design:** Follows strict prefab naming architecture for clear resource tracking:
  - `floor_grassPath2` / `floor_roadWithLineDashed_16m`
  - `building_apartmentBuilding10`

---

## ⚙️ Built With

* **Engine:** Unity (2021.3.9f1)
* **Scripting Language:** C#
* * **Graphics Pipeline:** Universal Render Pipeline (URP)
* **Camera System:** Cinemachine
* **Assets:** [City](https://assetstore.unity.com/packages/3d/environments/urban/city-package-107224), [Coffee Shop](https://assetstore.unity.com/packages/3d/props/coffeeshop-starter-pack-160914), [Table & Chair](https://assetstore.unity.com/packages/3d/props/barprops-137130)

---

**2023**

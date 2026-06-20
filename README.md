# Cofi Shop Tycoon — Environment Design & Lighting Test Project
A 3D project made in Unity to test how to set up indoor and outdoor maps, design building layouts, and handle game lighting (both static baked lights and real-time shadows) using the Universal Render Pipeline (URP).

The project is split into two different scenes to test two different camera styles: a large outdoor city map using a Third-Person (TPS) camera, and a detailed indoor coffee shop map using a First-Person (FPS) camera

---

## 🚀 Quick Start

Want to skip the code and just explore the environment? 

1. **[Download the Repository](https://github.com/Frext/CofiShopTycoon-repo/archive/refs/heads/main.zip)**

3. Extract the ZIP file.
  
5. **To test the Outdoor City (TPS):** Navigate to the `BuildWindows/City` folder and launch **`Cofi Shop Tycoon.exe`**.

7. **To test the Indoor Coffee Shop (FPS):** Navigate to the `BuildWindows/CofiShop` folder and launch **`Cofi Shop Tycoon.exe`**.

---

## 🎮 Controls

| Key | Action |
| :---: | :--- |
| **W A S D** | Move |
| **SPACE** | Jump |
| **MOUSE** | Look Around |

---

## 📸 Screenshots

### 🌆 Outdoor City Environment (TPS Scene)

#### Daytime City

| Daytime Aerial Overview | Nighttime Aerial Overview |
|:---:|:---:|
| <img src="" width="500" alt=""/> | <img src="" width="500" alt=""/> |

#### Nighttime City

| Central Residential Grid (Day) | Central Residential Grid (Night) |
|:---:|:---:|
| <img src="" width="500" alt=""/> | <img src="" width="500" alt=""/> |

### ☕ Indoor Coffee Shop (FPS Scene)

| Main Street View (Day) | Main Street View (Night) |
|:---:|:---:|
| <img src="" width="500" alt=""/> | <img src="" width="500" alt=""/> |

| Central Park Pathway (Night) | Third-Person Controller Intersection Scene |
|:---:|:---:|
| <img src="" width="500" alt=""/> | <img src="" width="500" alt=""/> |

---

## 🛠️ Main Features

- **Static & Dynamic Lighting:** Buildings and roads use pre-calculated (baked) lightmaps to save performance, while streetlights, traffic lights, and moving players cast real-time shadows.
- **URP Optimization:** Uses Unity's Universal Render Pipeline features like Ambient Occlusion (better contact shadows) and Post-Processing profiles to make the game look smooth and run well.
- **Two Unique Maps & Perspectives:**
  - **City Map (TPS):** A wide open map where you control a capsule player from behind using Cinemachine cameras.
  - **Coffee Shop Map (FPS):** A close-up indoor map viewed directly through the eyes of the player.
- **Day-Night Cycle:** Features a moving sun that changes the skybox color over time. It automatically turns on glowing windows and streetlights when it gets dark.
- **Organized Asset Placement:** Every piece of the map follows a strict naming system so files stay easy to find and reuse:
  - `floor_roadWithLineDashed_16m`
  - `building_apartmentBuilding10`

---

## ⚙️ Built With

* **Game Engine:** Unity (2021.3.9f1)
* **Scripting Language:** C#
* **Graphics Pipeline:** Universal Render Pipeline (URP)
* **Camera System:** Cinemachine
* **Assets Used:**
  * [City Package](https://assetstore.unity.com/packages/3d/environments/urban/city-package-107224)
  * [CoffeeShop Starter Pack](https://assetstore.unity.com/packages/3d/props/coffeeshop-starter-pack-160914)
  * [Bar Props Pack](https://assetstore.unity.com/packages/3d/props/barprops-137130)

---

**2023**

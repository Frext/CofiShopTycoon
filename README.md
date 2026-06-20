# Cofi Shop Tycoon — Environment Design & Lighting Test Project
A 3D project made in Unity to test how to set up indoor and outdoor maps, design building layouts, and handle game lighting (both static baked lights and real-time shadows) using the Universal Render Pipeline (URP).

The project is split into two different scenes to test two different camera styles: a large outdoor city map using a Third-Person (TPS) camera, and a detailed indoor cofi shop map using a First-Person (FPS) camera.

---

## 🚀 Quick Start

Want to skip the code and just explore the environment? 

1. **[Download the Repository](https://github.com/Frext/CofiShopTycoon-repo/archive/refs/heads/main.zip)**

2. Extract the ZIP file.
  
3. **To test the Outdoor City (TPS):** Navigate to the `BuildWindows/City` folder and launch **`Cofi Shop Tycoon.exe`**.

4. **To test the Indoor Cofi Shop (FPS):** Navigate to the `BuildWindows/CofiShop` folder and launch **`Cofi Shop Tycoon.exe`**.

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

#### ☀️ Daytime City

| Aerial View | City View 1 |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/f8ab61b5-423c-41c0-9fb2-6248e3b4ee1f" width="500" alt="Aerial View"/> | <img src="https://github.com/user-attachments/assets/47768c18-0aaf-43cb-8732-4063443f9bb0" width="500" alt="City View 1"/> |

| City View 2 | Hospital |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/9ca86cef-01f2-473e-bf09-7e7628ea192a" width="500" alt="City View 2"/> | <img src="https://github.com/user-attachments/assets/a23d8f91-5058-43c6-b021-67ad113f124d" width="500" alt="Hospital"/> |

| Gas Station | Central Park |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/b770ebd4-7023-4b54-a332-7b9761a9c509" width="500" alt="Gas Station"/> | <img src="https://github.com/user-attachments/assets/18bddb48-8aa5-4445-b5da-762b20ce90c9" width="500" alt="Central Park"/> |

| Residential Grid View 1 | Residential Grid View 2 |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/5dcc8a8d-4958-4861-ad6f-3ffd7ac809e9" width="500" alt="Residential Grid View 1"/> | <img src="https://github.com/user-attachments/assets/ed502f30-2b2d-404f-a06d-e39dcd4c3971" width="500" alt="Residential Grid View 2"/> |

| Middle Street | Third-Person View |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/1b903756-e721-41b3-8b15-f260afb636e7" width="500" alt="Middle Street"/> | <img src="https://github.com/user-attachments/assets/815c2c21-3f33-4d95-ac08-1c7c991c61cb" width="500" alt="Third-Person View"/> |

#### 🌙 Nighttime City

| Aerial View | City View 1 |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/bab07a29-5b25-4f14-b4f5-13082acfcb7d" width="500" alt="Aerial View"/> | <img src="https://github.com/user-attachments/assets/cee58380-b00b-4a8d-8ff5-304728fbeaa2" width="500" alt="City View 1"/> |

| City View 2 | Central Park |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/e96c64a3-7401-4068-a2c7-9064c8806010" width="500" alt="City View 2"/> | <img src="https://github.com/user-attachments/assets/be6f5c02-1b49-415b-b44e-5ed8492cabf9" width="500" alt="Central Park"/> |

| Middle Street | Residential Grid |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/e6148738-b0ab-454a-8d79-aaa07bfa1055" width="500" alt="Middle Street"/> | <img src="https://github.com/user-attachments/assets/5994587f-d6fc-44e2-b5e4-ed31a7b7555e" width="500" alt="Residential Grid"/> |

| Third-Person View 1 | Third-Person View 2 |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/f65b1e3b-d246-4d46-9afe-340ee2ddc927" width="500" alt="Third-Person View 1"/> | <img src="https://github.com/user-attachments/assets/7a65fcb6-f275-4fa8-82e9-cef47bd3b45e" width="500" alt="Third-Person View 2"/> |

### ☕ Indoor Cofi Shop (FPS Scene)

| Kitchen | Pastry Bar |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/6202ecca-0e5f-41c8-b619-c10fc24d238f" width="500" alt="Kitchen"/> | <img src="https://github.com/user-attachments/assets/2011f0bd-8270-4266-882d-59836d2a4320" width="500" alt="Pastry Bar"/> |


| Baking & Prep Station | Glass Display Cases |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/ddba58f2-a2ba-4c2d-a0c9-80f933ec09c5" width="500" alt="Baking & Prep Station"/> | <img src="https://github.com/user-attachments/assets/93a7b6a4-11d4-4c92-a9b7-e73c805ad15c" width="500" alt="Glass Display Cases"/> |

| Dining Layout View 1 | Dining Layout View 2 |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/ff98fcf7-5fcc-46ab-a0b1-6f6a47687800" width="500" alt="Dining Layout View 1"/> | <img src="https://github.com/user-attachments/assets/42faacff-c8a0-49b5-9400-98c89b92eb62" width="500" alt="Dining Layout View 2"/> |

---

## 🛠️ Main Features

- **Static & Dynamic Lighting:** Buildings and roads use pre-calculated (baked) lightmaps to save performance, while streetlights, traffic lights, and moving players cast real-time shadows.
- **URP Optimization:** Uses Unity's Universal Render Pipeline features like Ambient Occlusion (better contact shadows) and Post-Processing profiles to make the game look smooth and run well.
- **Two Unique Maps & Perspectives:**
  - **City Map (TPS):** A wide open map where you control a capsule player from behind using Cinemachine cameras.
  - **Cofi Shop Map (FPS):** A close-up indoor map viewed directly through the eyes of the player.
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

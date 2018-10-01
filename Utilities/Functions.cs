using Binjector.Cheats;
using Binjector.Other;
using SDG.Unturned;
using Steamworks;
using System;
using System.Reflection;
using UnityEngine;

namespace Binjector.Utilities
{
    public class Functions
    {
        public static GUIStyle style;
        public static int fontsize = 11;

        public static SteamPlayer GetSteamPlayer(Player player)
        {
            foreach (var user in Provider.clients)
            {
                if (user.player == player)
                    return user;
            }

            return null;
        }

        public static float GetDistance(Vector3 endpos)
        {
            return (float)Math.Round(Vector3.Distance(ESPUtil.mainCamera.transform.position, endpos));
        }

        public static bool InCameraView(Vector3 pos, out RaycastHit result)
        {
            Vector3 dir = (pos - MainCamera.instance.transform.position).normalized;
            return Physics.Raycast(MainCamera.instance.transform.position, dir, out result, Mathf.Infinity, RayMasks.DAMAGE_CLIENT);
        }

        public static SteamPlayer GetPlayerFromSteamID(CSteamID steamid)
        {
            foreach (var user in Provider.clients)
            {
                if (user.playerID.steamID == steamid)
                    return user;
            }

            return null;
        }

        public static SteamPlayer GetPlayerFromSteamID(string steamid)
        {
            foreach (var user in Provider.clients)
            {
                if (user.playerID.steamID.ToString() == steamid.ToString())
                    return user;
            }

            return null;
        }

        public static double GetDistFrom(Vector3 start, Vector3 end)
        {
            Vector3 vector;
            vector.x = start.x - end.x;
            vector.y = start.y - end.y;
            vector.z = start.z - end.z;
            return Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        public static Player GetNearestPlayer()
        {
            SteamPlayer[] players = Aimbot.players;
            Player p = null;

            players = Provider.clients.ToArray();

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].playerID.steamID != Provider.client && players[i].player.life != null && !players[i].player.life.isDead && !Functions.isFriend(players[i].playerID.steamID.ToString()))
                {
                    if (p == null)
                    {
                        p = players[i].player;
                    }
                    else if (MenuGUI.instance.FOVAim)
                    {
                        Vector3 vector = ESPUtil.mainCamera.WorldToScreenPoint(GetLimbPosition(players[i].player.transform, "Skull"));
                        if (vector.z > 0f)
                        {
                            Vector2 vector2;
                            vector2 = new Vector2(vector.x, vector.y);
                            float num = Vector2.Distance(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), vector2);
                            if (num < 360 && p == null)
                            {
                                p = players[i].player;
                            }
                            else if (num < 360)
                            {
                                Vector3 vector3 = ESPUtil.mainCamera.WorldToScreenPoint(GetLimbPosition(p.transform, "Skull"));
                                Vector2 vector4;
                                vector4 = new Vector2(vector3.x, vector3.y);
                                if (Vector2.Distance(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), vector4) > num)
                                {
                                    p = players[i].player;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(ESPUtil.mainCamera.transform.position, p.transform.position) > Vector3.Distance(ESPUtil.mainCamera.transform.position, players[i].player.transform.position))
                        {
                            p = players[i].player;
                        }
                    }
                }
            }
            return p;
        }

        public static bool isFriend(string steamId)
        {
            foreach (string steamid in MenuGUI.friends)
            {
                //kr4kens gay lol
                if (steamid == steamId || (Player.player.quests.isMemberOfSameGroupAs(GetPlayerFromSteamID(steamId).player))) return true;
            }
            return false;
        }

        //only if in your screen view
        public static bool IsVisable(Transform transform)
        {
            var scrnpt = ESPUtil.mainCamera.WorldToViewportPoint(transform.position);

            if (scrnpt.z <= 0f || scrnpt.x <= 0f || scrnpt.x >= 1f || scrnpt.y <= 0f || scrnpt.y >= 1f)
                return false;

            return true;
        }

        public static void OverrideMethod(Type defaultClass, Type overrideClass, string method, BindingFlags bindingflag, BindingFlags bindingflag1)
        {
            string overriddenmethod = "OV_" + method;
            RedirectionHelper.RedirectCalls(defaultClass.GetMethod(method, bindingflag | bindingflag1), overrideClass.GetMethod(overriddenmethod, BindingFlags.Static | BindingFlags.Public));
        }

        public static Vector3 GetLimbPosition(Transform target, string objName)
        {
            var componentsInChildren = target.transform.GetComponentsInChildren<Transform>();
            var result = Vector3.zero;

            if (componentsInChildren == null) return result;

            foreach (var transform in componentsInChildren)
            {
                if (transform.name.Trim() != objName) continue;

                result = transform.position + new Vector3(0f, 0.4f, 0f);
                break;
            }

            return result;
        }

        public static void Draw3DBox(Bounds b, Color color)
        {
            Vector3[] pts = new Vector3[8];
            pts[0] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
            pts[1] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
            pts[2] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
            pts[3] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
            pts[4] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
            pts[5] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
            pts[6] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
            pts[7] = ESPUtil.mainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));

            for (int i = 0; i < pts.Length; i++) pts[i].y = Screen.height - pts[i].y;

            GL.PushMatrix();
            GL.Begin(1);
            ESPUtil.DrawingMaterial.SetPass(0);
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Begin(1);
            ESPUtil.DrawingMaterial.SetPass(0);
            GL.Color(color);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);

            GL.End();
            GL.PopMatrix();

        }

        public static void Draw2DBox(Transform target, Vector3 position, Color color, Vector3 targetPos)
        {
            var scrnPt = ESPUtil.mainCamera.WorldToScreenPoint(targetPos);
            scrnPt.y = Screen.height - scrnPt.y;

            var dist = Math.Abs(position.y - scrnPt.y);
            var hlfDist = dist / 2f;
            var xVal = position.x - hlfDist / 2f;
            var yVal = position.y - dist;

            GL.PushMatrix();
            GL.Begin(1);
            ESPUtil.DrawingMaterial.SetPass(0);
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Begin(1);
            ESPUtil.DrawingMaterial.SetPass(0);
            GL.Color(color);

            GL.Vertex3(xVal, yVal, 0f);
            GL.Vertex3(xVal, yVal + dist, 0f);

            GL.Vertex3(xVal, yVal, 0f);
            GL.Vertex3(xVal + hlfDist, yVal, 0f);

            GL.Vertex3(xVal + hlfDist, yVal, 0f);
            GL.Vertex3(xVal + hlfDist, yVal + dist, 0f);

            GL.Vertex3(xVal, yVal + dist, 0f);
            GL.Vertex3(xVal + hlfDist, yVal + dist, 0f);

            GL.End();
            GL.PopMatrix();
        }
        public static void DrawLabel(string content, Color color, Vector3 pos)
        {
            GUIContent val = new GUIContent(content);
            GUIStyle style = GUI.skin.label;
            pos.x -= style.CalcSize(val).x / 2f;
            GUI.contentColor = color;
            GUI.Label(new Rect(pos.x, pos.y, 1000f, 300f), "<size=" + fontsize + ">" + content + "</size>");
        }
        public static void DrawBoxLabel(string content, Color color, Vector3 pos)
        {
            GUIContent stringcontents = new GUIContent(content);
            Vector2 size = style.CalcSize(stringcontents);
            GUI.contentColor = color;
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x + 5f, size.y + 5f));
            GUILayout.Box(content);
            GUI.EndGroup();
        }
        public static void DrawTracer(Vector3 pos, Color color)
        {
            GL.PushMatrix();
            GL.Begin(1);
            ESPUtil.DrawingMaterial.SetPass(0);
            GL.Color(color);
            GL.Vertex3(Screen.width / 2, Screen.height / 2, 0f);
            GL.Vertex3(pos.x, pos.y, 0f);
            GL.End();
            GL.PopMatrix();
        }
        public static void DrawHighlight(GameObject obj, Color color)
        {
            HighlightingSystem.Highlighter h = obj.GetComponent<HighlightingSystem.Highlighter>();
            if (h == null)
            {
                h = obj.AddComponent<HighlightingSystem.Highlighter>();
            }
            h.OccluderOn();
            h.SeeThroughOn();
            h.ConstantOn(color);
        }

        public static void ChangeEngine(InteractableVehicle car, EEngine engine)
        {
            car.asset.GetType().GetField("_engine", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SetValue(car.asset, engine);
        }
    }
}

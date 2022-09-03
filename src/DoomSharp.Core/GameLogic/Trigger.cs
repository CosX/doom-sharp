﻿using System.Globalization;
using DoomSharp.Core.Graphics;
using DoomSharp.Core.Data;

namespace DoomSharp.Core.GameLogic;

public static class Trigger
{
    public static void Handle(Line line, int side, MapObject thing)
    {
        // Note: could use some const's here.
        switch (line.Special)
        {
            case 2:
                // Open door
                DoorEvent(line, DoorType.Open);
                line.Special = 0;
                break;

            case 3:
                // Close door
                DoorEvent(line, DoorType.Close);
                line.Special = 0;
                break;

            case 4:
                // Raise door
                DoorEvent(line, DoorType.Normal);
                line.Special = 0;
                break;

            case 5:
                // Raise floor
                FloorEvent(line, FloorType.RaiseFloor);
                line.Special = 0;
                break;

            case 6:
                // Fast ceiling crush & raise
                CeilingEvent(line, CeilingType.FastCrushAndRaise);
                line.Special = 0;
                break;

            case 8:
                // Build stairs
                BuildStairsEvent(line, StaircaseType.Build8);
                line.Special = 0;
                break;

            case 10:
                // Platform down wait up
                PlatformEvent(line, PlatformType.DownWaitUpStay, 0);
                line.Special = 0;
                break;

            case 12:
                // Light turn on - brightest near
                LightTurnOnEvent(line, 0);
                line.Special = 0;
                break;

            case 13:
                // Light turn on 255
                LightTurnOnEvent(line, 255);
                line.Special = 0;
                break;

            case 16:
                // Close door 30
                DoorEvent(line, DoorType.Close30ThenOpen);
                line.Special = 0;
                break;

            case 17:
                // Light strobing
                LightStrobingEvent(line);
                line.Special = 0;
                break;

            case 19:
                // Lower floor
                FloorEvent(line, FloorType.LowerFloor);
                line.Special = 0;
                break;

            case 22:
                // Raise floor to nearest height and change texture
                PlatformEvent(line, PlatformType.RaiseToNearestAndChange, 0);
                line.Special = 0;
                break;

            case 25:
                // Ceiling crush and raise
                CeilingEvent(line, CeilingType.CrushAndRaise);
                line.Special = 0;
                break;

            case 30:
                // Raise floor to shortest texture height on either side of lines
                FloorEvent(line, FloorType.RaiseToTexture);
                line.Special = 0;
                break;

            case 35:
                // Lights very dark
                LightTurnOnEvent(line, 35);
                line.Special = 0;
                break;

            case 36:
                // Lower floor (TURBO)
                FloorEvent(line, FloorType.TurboLower);
                line.Special = 0;
                break;

            case 37:
                // Lower and change
                FloorEvent(line, FloorType.LowerAndChange);
                line.Special = 0;
                break;

            case 38:
                // Lower floor to lowest
                FloorEvent(line, FloorType.LowerFloorToLowest);
                line.Special = 0;
                break;

            case 39:
                // Teleport
                TeleportEvent(line, side, thing);
                line.Special = 0;
                break;

            case 40:
                // Raise ceiling lower floor
                CeilingEvent(line, CeilingType.RaiseToHighest);
                FloorEvent(line, FloorType.LowerFloorToLowest);
                line.Special = 0;
                break;

            case 44:
                // ceiling crush
                CeilingEvent(line, CeilingType.LowerAndCrush);
                line.Special = 0;
                break;

            case 52:
                // EXIT!
                DoomGame.Instance.Game.ExitLevel();
                break;

            case 53:
                // Perpetual platform raise
                PlatformEvent(line, PlatformType.PerpetualRaise, 0);
                line.Special = 0;
                break;

            case 54:
                // Platform Stop
                DoomGame.Instance.Game.StopPlatformEvent(line);
                line.Special = 0;
                break;

            case 56:
                // Raise floor crush
                FloorEvent(line, FloorType.RaiseFloorCrush);
                line.Special = 0;
                break;

            case 57:
                // Ceiling crush stop
                DoomGame.Instance.Game.CeilingCrushStopEvent(line);
                line.Special = 0;
                break;

            case 58:
                // Raise floor 24
                FloorEvent(line, FloorType.RaiseFloor24);
                line.Special = 0;
                break;

            case 59:
                // Raise floor 24 and change
                FloorEvent(line, FloorType.RaiseFloor24AndChange);
                line.Special = 0;
                break;

            case 72:
                // Ceiling Crush
                CeilingEvent(line, CeilingType.LowerAndCrush);
                break;

            case 73:
                // Ceiling Crush and Raise
                CeilingEvent(line, CeilingType.CrushAndRaise);
                break;

            case 74:
                // Ceiling Crush Stop
                DoomGame.Instance.Game.CeilingCrushStopEvent(line);
                break;

            case 75:
                // Close Door
                DoorEvent(line, DoorType.Close);
                break;

            case 76:
                // Close Door 30
                DoorEvent(line, DoorType.Close30ThenOpen);
                break;

            case 77:
                // Fast Ceiling Crush & Raise
                CeilingEvent(line, CeilingType.FastCrushAndRaise);
                break;

            case 79:
                // Lights Very Dark
                LightTurnOnEvent(line, 35);
                break;

            case 80:
                // Light Turn On - brightest near
                LightTurnOnEvent(line, 0);
                break;

            case 81:
                // Light Turn On 255
                LightTurnOnEvent(line, 255);
                break;

            case 82:
                // Lower Floor To Lowest
                FloorEvent(line, FloorType.LowerFloorToLowest);
                break;

            case 83:
                // Lower Floor
                FloorEvent(line, FloorType.LowerFloor);
                break;

            case 84:
                // LowerAndChange
                FloorEvent(line, FloorType.LowerAndChange);
                break;

            case 86:
                // Open Door
                DoorEvent(line, DoorType.Open);
                break;

            case 87:
                // Perpetual Platform Raise
                PlatformEvent(line, PlatformType.PerpetualRaise, 0);
                break;

            case 88:
                // PlatDownWaitUp
                PlatformEvent(line, PlatformType.DownWaitUpStay, 0);
                break;

            case 89:
                // Platform Stop
                DoomGame.Instance.Game.StopPlatformEvent(line);
                break;

            case 90:
                // Raise Door
                DoorEvent(line, DoorType.Normal);
                break;

            case 91:
                // Raise Floor
                FloorEvent(line, FloorType.RaiseFloor);
                break;

            case 92:
                // Raise Floor 24
                FloorEvent(line, FloorType.RaiseFloor24);
                break;

            case 93:
                // Raise Floor 24 And Change
                FloorEvent(line, FloorType.RaiseFloor24AndChange);
                break;

            case 94:
                // Raise Floor Crush
                FloorEvent(line, FloorType.RaiseFloorCrush);
                break;

            case 95:
                // Raise floor to nearest height
                // and change texture.
                PlatformEvent(line, PlatformType.RaiseToNearestAndChange, 0);
                break;

            case 96:
                // Raise floor to shortest texture height
                // on either side of lines.
                FloorEvent(line, FloorType.RaiseToTexture);
                break;

            case 97:
                // TELEPORT!
                TeleportEvent(line, side, thing);
                break;

            case 98:
                // Lower Floor (TURBO)
                FloorEvent(line, FloorType.TurboLower);
                break;

            case 100:
                // Build stairs turbo 16
                BuildStairsEvent(line, StaircaseType.Turbo16);
                line.Special = 0;
                break;

            case 104:
                // Turn lights off in sector(tag)
                TagLightsTurnOffEvent(line);
                line.Special = 0;
                break;

            case 105:
                // Blazing Door Raise (faster than TURBO!)
                DoorEvent(line, DoorType.BlazeRaise);
                break;

            case 106:
                // Blazing Door Open (faster than TURBO!)
                DoorEvent(line, DoorType.BlazeOpen);
                break;

            case 107:
                // Blazing Door Close (faster than TURBO!)
                DoorEvent(line, DoorType.BlazeClose);
                break;

            case 108:
                // Blazing door raise (faster than turbo)
                DoorEvent(line, DoorType.BlazeRaise);
                line.Special = 0;
                break;

            case 109:
                // Blazing door open (faster than turbo)
                DoorEvent(line, DoorType.BlazeOpen);
                line.Special = 0;
                break;

            case 110:
                // Blazing door close (faster than turbo)
                DoorEvent(line, DoorType.BlazeClose);
                line.Special = 0;
                break;

            case 119:
                // Raise floor to nearest surrounding floor
                FloorEvent(line, FloorType.RaiseFloorToNearest);
                line.Special = 0;
                break;

            case 120:
                // Blazing PlatDownWaitUpStay.
                PlatformEvent(line, PlatformType.BlazeDWUS, 0);
                break;

            case 121:
                // Blazing platfownwaitupstay
                PlatformEvent(line, PlatformType.BlazeDWUS, 0);
                line.Special = 0;
                break;

            case 124:
                DoomGame.Instance.Game.SecretExitLevel();
                break;

            case 125:
                // teleport monster only
                if (thing.Player == null)
                {
                    TeleportEvent(line, side, thing);
                    line.Special = 0;
                }

                break;

            case 126:
                // TELEPORT MonsterONLY.
                if (thing.Player == null)
                {
                    TeleportEvent(line, side, thing);
                }
                break;

            case 128:
                // Raise To Nearest Floor
                FloorEvent(line, FloorType.RaiseFloorToNearest);
                break;

            case 129:
                // Raise Floor Turbo
                FloorEvent(line, FloorType.RaiseFloorTurbo);
                break;

            case 130:
                // Raise Floor Turbo
                FloorEvent(line, FloorType.RaiseFloorTurbo);
                line.Special = 0;
                break;

            case 141:
                // Silent Ceiling Crush & Raise
                CeilingEvent(line, CeilingType.SilentCrushAndRaise);
                line.Special = 0;
                break;
        }
    }

    private static void VerticalDoor(ActionParams actionParams)
    {
        if (actionParams.Thinker is not Door door)
        {
            return;
        }

        switch (door.Direction)
        {
            case 0:
                // waiting
                if (--door.TopCountDown == 0)
                {
                    switch (door.Type)
                    {
                        case DoorType.BlazeRaise:
                            door.Direction = -1; // time to go back down
                            //S_StartSound((mobj_t*)&door->sector->soundorg,
                            //    sfx_bdcls);
                            break;

                        case DoorType.Normal:
                            door.Direction = -1; // time to go back down
                            //S_StartSound((mobj_t*)&door->sector->soundorg,
                            //    sfx_dorcls);
                            break;

                        case DoorType.Close30ThenOpen:
                            door.Direction = 1;
                            //S_StartSound((mobj_t*)&door->sector->soundorg,
                            //    sfx_doropn);
                            break;
                    }
                }

                break;

            case 2:
                // initial wait
                if (--door.TopCountDown == 0)
                {
                    if (door.Type == DoorType.RaiseIn5Mins)
                    {
                        door.Direction = 1;
                        door.Type = DoorType.Normal;
                        //S_StartSound((mobj_t*)&door->sector->soundorg,
                        //    sfx_doropn);
                    }
                }

                break;

            case -1:
                // down
                var res = MovePlane(door.Sector!, door.Speed, door.Sector!.FloorHeight, false, 1, door.Direction);
                if (res == Result.PastDest)
                {
                    switch (door.Type)
                    {
                        case DoorType.BlazeRaise:
                        case DoorType.BlazeClose:
                            door.Sector.SpecialData = null;
                            DoomGame.Instance.Game.RemoveThinker(door); // unlink and free
                            //S_StartSound((mobj_t*)&door->sector->soundorg,
                            //    sfx_bdcls);
                            break;

                        case DoorType.Normal:
                        case DoorType.Close:
                            door.Sector.SpecialData = null;
                            DoomGame.Instance.Game.RemoveThinker(door); // unlink and free
                            break;

                        case DoorType.Close30ThenOpen:
                            door.Direction = 0;
                            door.TopCountDown = 35 * 30;
                            break;
                    }
                }
                else if (res == Result.Crushed)
                {
                    switch (door.Type)
                    {
                        case DoorType.BlazeClose:
                        case DoorType.Close:
                            // do not go back up!
                            break;

                        default:
                            door.Direction = 1;
                            //S_StartSound((mobj_t*)&door->sector->soundorg,
                            //    sfx_doropn);
                            break;
                    }
                }

                break;

            case 1:
                // up
                res = MovePlane(door.Sector!, door.Speed, door.TopHeight, false, 1, door.Direction);
                if (res == Result.PastDest)
                {
                    switch (door.Type)
                    {
                        case DoorType.BlazeRaise:
                        case DoorType.Normal:
                            door.Direction = 0; // wait at top
                            door.TopCountDown = door.TopWait;
                            break;

                        case DoorType.Close30ThenOpen:
                        case DoorType.BlazeOpen:
                        case DoorType.Open:
                            door.Sector!.SpecialData = null;
                            DoomGame.Instance.Game.RemoveThinker(door);
                            break;
                    }
                }
                break;
        }
    }

    public static int DoorEvent(Line line, DoorType type)
    {
        var secnum = -1;
        var game = DoomGame.Instance.Game;

        var rtn = 0;

        while ((secnum = game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var sec = game.Sectors[secnum];
            if (sec.SpecialData != null)
            {
                continue;
            }

            // new door thinker
            rtn = 1;
            var door = new Door();
            game.AddThinker(door);
            sec.SpecialData = door;

            door.Action = VerticalDoor;
            door.Sector = sec;
            door.Type = type;
            door.TopWait = Door.Wait;
            door.Speed = Door.DefaultSpeed;

            switch (type)
            {
                case DoorType.BlazeClose:
                    door.TopHeight = game.P_FindLowestCeilingSurrounding(sec);
                    door.TopHeight -= 4 * Constants.FracUnit;
                    door.Direction = -1;
                    door.Speed = Door.DefaultSpeed * 4;
                    //S_StartSound((mobj_t*)&door->sector->soundorg,
                    //    sfx_bdcls);
                    break;

                case DoorType.Close:
                    door.TopHeight = game.P_FindLowestCeilingSurrounding(sec);
                    door.TopHeight -= 4 * Constants.FracUnit;
                    door.Direction = -1;
                    //S_StartSound((mobj_t*)&door->sector->soundorg,
                    //    sfx_dorcls);
                    break;

                case DoorType.Close30ThenOpen:
                    door.TopHeight = sec.CeilingHeight;
                    door.Direction = -1;
                    //S_StartSound((mobj_t*)&door->sector->soundorg,
                    //    sfx_dorcls);
                    break;

                case DoorType.BlazeRaise:
                case DoorType.BlazeOpen:
                    door.Direction = 1;
                    door.TopHeight = game.P_FindLowestCeilingSurrounding(sec);
                    door.TopHeight -= 4 * Constants.FracUnit;
                    door.Speed = Door.DefaultSpeed * 4;
                    if (door.TopHeight != sec.CeilingHeight)
                    {
                        //S_StartSound((mobj_t*)&door->sector->soundorg,
                        //    sfx_bdopn);
                    }
                    break;

                case DoorType.Normal:
                case DoorType.Open:
                    door.Direction = 1;
                    door.TopHeight = game.P_FindLowestCeilingSurrounding(sec);
                    door.TopHeight -= 4 * Constants.FracUnit;
                    if (door.TopHeight != sec.CeilingHeight)
                    {
                        //S_StartSound((mobj_t*)&door->sector->soundorg,
                        //    sfx_doropn);
                    }
                    break;
            }
        }

        return rtn;
    }

    /// <summary>
    /// Move a plane (floor or ceiling) and check for crushing
    /// </summary>
    private static Result MovePlane(Sector sector, Fixed speed, Fixed dest, bool crush, int floorOrCeiling, int direction)
    {
        Fixed lastPos;
        bool flag;

        switch (floorOrCeiling)
        {
            case 0:
                // floor

                switch (direction)
                {
                    case -1: //down
                        if (sector.FloorHeight - speed < dest)
                        {
                            lastPos = sector.FloorHeight;
                            sector.FloorHeight = dest;
                            flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            if (flag)
                            {
                                sector.FloorHeight = lastPos;
                                DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                                // return crushed;
                            }

                            return Result.PastDest;
                        }
                        else
                        {
                            lastPos = sector.FloorHeight;
                            sector.FloorHeight -= speed;
                            flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            if (flag)
                            {
                                sector.FloorHeight = lastPos;
                                DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                                return Result.Crushed;
                            }
                        }

                        break;

                    case 1: // up
                        if (sector.FloorHeight + speed > dest)
                        {
                            lastPos = sector.FloorHeight;
                            sector.FloorHeight = dest;
                            flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            if (flag)
                            {
                                sector.FloorHeight = lastPos;
                                DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            }

                            return Result.PastDest;
                        }

                        // could get crushed
                        lastPos = sector.FloorHeight;
                        sector.FloorHeight += speed;
                        flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                        if (flag)
                        {
                            if (crush)
                            {
                                return Result.Crushed;
                            }

                            sector.FloorHeight = lastPos;
                            DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            return Result.Crushed;
                        }

                        break;
                }

                break;

            case 1: // ceiling
                switch (direction)
                {
                    case -1: // down
                        if (sector.CeilingHeight - speed < dest)
                        {
                            lastPos = sector.CeilingHeight;
                            sector.CeilingHeight = dest;
                            flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);

                            if (flag)
                            {
                                sector.CeilingHeight = lastPos;
                                DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            }

                            return Result.PastDest;
                        }

                        // could get crushed
                        lastPos = sector.CeilingHeight;
                        sector.CeilingHeight -= speed;
                        flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);

                        if (flag)
                        {
                            if (crush)
                            {
                                return Result.Crushed;
                            }

                            sector.CeilingHeight = lastPos;
                            DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            return Result.Crushed;
                        }

                        break;

                    case 1: // up
                        if (sector.CeilingHeight + speed > dest)
                        {
                            lastPos = sector.CeilingHeight;
                            sector.CeilingHeight = dest;
                            flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            if (flag)
                            {
                                sector.CeilingHeight = lastPos;
                                DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                            }

                            return Result.PastDest;
                        }

                        lastPos = sector.CeilingHeight;
                        sector.CeilingHeight += speed;
                        flag = DoomGame.Instance.Game.P_ChangeSector(sector, crush);
                        break;
                }

                break;
        }

        return Result.Ok;
    }

    private static void MoveFloor(ActionParams actionParams)
    {
        if (actionParams.Thinker is not Floor floor)
        {
            return;
        }

        var res = MovePlane(floor.Sector!, floor.Speed, floor.FloorDestHeight, floor.Crush, 0, floor.Direction);

        if ((DoomGame.Instance.Game.LevelTime & 7) == 0)
        {
            //S_StartSound((mobj_t*)&floor->sector->soundorg,
            //    sfx_stnmov);
        }

        if (res == Result.PastDest)
        {
            floor.Sector!.SpecialData = null;

            if (floor.Direction == 1)
            {
                if (floor.Type == FloorType.DonutRaise)
                {
                    floor.Sector.Special = (short)floor.NewSpecial;
                    floor.Sector.FloorPic = floor.Texture;
                }
            }
            else if (floor.Direction == -1)
            {
                if (floor.Type == FloorType.LowerAndChange)
                {
                    floor.Sector.Special = (short)floor.NewSpecial;
                    floor.Sector.FloorPic = floor.Texture;
                }
            }

            DoomGame.Instance.Game.RemoveThinker(floor);
            //S_StartSound((mobj_t*)&floor->sector->soundorg,
            //    sfx_pstop);
        }
    }

    public static int FloorEvent(Line line, FloorType type)
    {
        var secnum = -1;
        var rtn = 0;
        var game = DoomGame.Instance.Game;
        var renderer = DoomGame.Instance.Renderer;

        while ((secnum = game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var sec = game.Sectors[secnum];

            // already moving? if so, keep going...
            if (sec.SpecialData != null)
            {
                continue;
            }

            // new floor thinker
            rtn = 1;
            var floor = new Floor();
            game.AddThinker(floor);
            sec.SpecialData = floor;
            floor.Action = MoveFloor;
            floor.Type = type;
            floor.Crush = false;

            switch (type)
            {
                case FloorType.LowerFloor:
                    floor.Direction = -1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = game.P_FindHighestFloorSurrounding(sec);
                    break;

                case FloorType.LowerFloorToLowest:
                    floor.Direction = -1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = game.P_FindLowestFloorSurrounding(sec);
                    break;

                case FloorType.TurboLower:
                    floor.Direction = -1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed * 4;
                    floor.FloorDestHeight = game.P_FindHighestFloorSurrounding(sec);
                    if (floor.FloorDestHeight != sec.FloorHeight)
                    {
                        floor.FloorDestHeight += 8 * Constants.FracUnit;
                    }
                    break;

                case FloorType.RaiseFloorCrush:
                    floor.Crush = true;
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = game.P_FindLowestCeilingSurrounding(sec);
                    if (floor.FloorDestHeight > sec.CeilingHeight)
                    {
                        floor.FloorDestHeight = sec.CeilingHeight;
                    }
                    floor.FloorDestHeight -= (8 * Constants.FracUnit);
                    break;

                case FloorType.RaiseFloor:
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = game.P_FindLowestCeilingSurrounding(sec);
                    if (floor.FloorDestHeight > sec.CeilingHeight)
                    {
                        floor.FloorDestHeight = sec.CeilingHeight;
                    }
                    break;

                case FloorType.RaiseFloorTurbo:
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed * 4;
                    floor.FloorDestHeight = game.P_FindNextHighestFloor(sec, sec.FloorHeight);
                    break;

                case FloorType.RaiseFloorToNearest:
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = game.P_FindNextHighestFloor(sec, sec.FloorHeight);
                    break;

                case FloorType.RaiseFloor24:
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = floor.Sector.FloorHeight + (24 * Constants.FracUnit);
                    break;

                case FloorType.RaiseFloor512:
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = floor.Sector.FloorHeight + (512 * Constants.FracUnit);
                    break;

                case FloorType.RaiseFloor24AndChange:
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = floor.Sector.FloorHeight + (24 * Constants.FracUnit);
                    sec.FloorPic = line.FrontSector!.FloorPic;
                    sec.Special = line.FrontSector.Special;
                    break;

                case FloorType.RaiseToTexture:
                {
                    var minSize = int.MaxValue;

                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    for (var i = 0; i < sec.LineCount; i++)
                    {
                        if (TwoSided(secnum, i))
                        {
                            var side = GetSide(secnum, i, 0);
                            if (side.BottomTexture >= 0)
                            {
                                if (renderer.TextureHeight[side.BottomTexture] < minSize)
                                {
                                    minSize = renderer.TextureHeight[side.BottomTexture];
                                }
                            }

                            side = GetSide(secnum, i, 1);
                            if (side.BottomTexture >= 0)
                            {
                                if (renderer.TextureHeight[side.BottomTexture] < minSize)
                                {
                                    minSize = renderer.TextureHeight[side.BottomTexture];
                                }
                            }
                        }
                    }

                    floor.FloorDestHeight = floor.Sector.FloorHeight + minSize;
                }
                    break;

                case FloorType.LowerAndChange:
                    floor.Direction = -1;
                    floor.Sector = sec;
                    floor.Speed = Floor.FloorSpeed;
                    floor.FloorDestHeight = game.P_FindLowestFloorSurrounding(sec);
                    floor.Texture = sec.FloorPic;

                    for (var i = 0; i < sec.LineCount; i++)
                    {
                        if (TwoSided(secnum, i))
                        {
                            if (IsSideSectorCurrent(secnum, i, 0))
                            {
                                sec = GetSector(secnum, i, 1);

                                if (sec.FloorHeight == floor.FloorDestHeight)
                                {
                                    floor.Texture = sec.FloorPic;
                                    floor.NewSpecial = sec.Special;
                                    break;
                                }
                            }
                            else
                            {
                                sec = GetSector(secnum, i, 0);

                                if (sec.FloorHeight == floor.FloorDestHeight)
                                {
                                    floor.Texture = sec.FloorPic;
                                    floor.NewSpecial = sec.Special;
                                    break;
                                }
                            }
                        }
                    }

                    break;
            }
        }

        return rtn;
    }

    private static int BuildStairsEvent(Line line, StaircaseType type)
    {
        var rtn = 0;
        var secnum = -1;
        var game = DoomGame.Instance.Game;

        var speed = 0;
        var stairSize = 0;
        var ok = false;

        while ((secnum = game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var sec = game.Sectors[secnum];

            // already moving? If so, keep going...
            if (sec.SpecialData != null)
            {
                continue;
            }

            // new floor thinker
            rtn = 1;
            var floor = new Floor();
            game.AddThinker(floor);
            sec.SpecialData = floor;
            floor.Action = MoveFloor;
            floor.Direction = 1;
            floor.Sector = sec;

            switch (type)
            {
                case StaircaseType.Build8:
                    speed = Floor.FloorSpeed / 4;
                    stairSize = 8 * Constants.FracUnit;
                    break;

                case StaircaseType.Turbo16:
                    speed = Floor.FloorSpeed * 4;
                    stairSize = 16 * Constants.FracUnit;
                    break;
            }

            floor.Speed = speed;
            var height = sec.FloorHeight + stairSize;
            floor.FloorDestHeight = height;

            var texture = sec.FloorPic;

            // Find next sector to raise
            // 1. Find 2-sided line with same sector side[0]
            // 2. Other side is the next sector to raise
            do
            {
                ok = false;
                for (var i = 0; i < sec.LineCount; i++)
                {
                    var secLine = sec.Lines[i];
                    if ((secLine.Flags & Constants.Line.TwoSided) == 0)
                    {
                        continue;
                    }

                    var tsec = secLine.FrontSector!;
                    if (game.Sectors.IndexOf(tsec) != secnum)
                    {
                        continue;
                    }

                    tsec = secLine.BackSector!;
                    var newSecNum = game.Sectors.IndexOf(tsec);

                    if (tsec.FloorPic != texture)
                    {
                        continue;
                    }

                    height += stairSize;

                    if (tsec.SpecialData != null)
                    {
                        continue;
                    }

                    sec = tsec;
                    secnum = newSecNum;
                    
                    floor = new Floor();
                    game.AddThinker(floor);
                    sec.SpecialData = floor;
                    floor.Action = MoveFloor;
                    floor.Direction = 1;
                    floor.Sector = sec;
                    floor.Speed = speed;
                    floor.FloorDestHeight = height;
                    ok = true;
                    break;
                }
            } while (ok);
        }

        return rtn;
    }

    private static int DonutEvent(Line line)
    {
        var rtn = 0;
        var secnum = -1;
        var game = DoomGame.Instance.Game;

        while ((secnum = game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var s1 = game.Sectors[secnum];

            // already moving? if so, keep going...
            if (s1.SpecialData != null)
            {
                continue;
            }

            rtn = 1;
            var s2 = s1.Lines[0].GetNextSector(s1)!;
            for (var i = 0; i < s2.LineCount; i++)
            {
                if ((s2.Lines[i].Flags & Constants.Line.TwoSided) == 0 ||
                    s2.Lines[i].BackSector == s1)
                {
                    continue;
                }

                var s3 = s2.Lines[i].BackSector!;

                // Spawn rising slime
                var floor = new Floor();
                game.AddThinker(floor);
                s2.SpecialData = floor;

                floor.Action = MoveFloor;
                floor.Type = FloorType.DonutRaise;
                floor.Crush = false;
                floor.Direction = 1;
                floor.Sector = s2;
                floor.Speed = Floor.FloorSpeed / 2;
                floor.Texture = s3.FloorPic;
                floor.NewSpecial = 0;
                floor.FloorDestHeight = s3.FloorHeight;

                // Spawn lowering donut hole
                floor = new Floor();
                game.AddThinker(floor);
                s1.SpecialData = floor;

                floor.Action = MoveFloor;
                floor.Type = FloorType.LowerFloor;
                floor.Crush = false;
                floor.Direction = -1;
                floor.Sector = s1;
                floor.Speed = Floor.FloorSpeed / 2;
                floor.FloorDestHeight = s3.FloorHeight;
                break;
            }
        }

        return rtn;
    }

    public static void MoveCeiling(ActionParams actionParams)
    {
        if (actionParams.Thinker is not Ceiling ceiling)
        {
            return;
        }

        var game = DoomGame.Instance.Game;
        switch (ceiling.Direction)
        {
            case 0: // in stasis
                break;

            case 1: // up
                var res = MovePlane(ceiling.Sector!, ceiling.Speed, ceiling.TopHeight, false, 1, ceiling.Direction);

                if ((game.LevelTime & 7) == 0)
                {
                    switch (ceiling.Type)
                    {
                        case CeilingType.SilentCrushAndRaise:
                            break;
                        default:
                            //S_StartSound((mobj_t*)&ceiling->sector->soundorg,
                            //    sfx_stnmov);
                            break;
                    }
                }

                if (res == Result.PastDest)
                {
                    switch (ceiling.Type)
                    {
                        case CeilingType.RaiseToHighest:
                            game.P_RemoveActiveCeiling(ceiling);
                            break;

                        case CeilingType.SilentCrushAndRaise:
                        //S_StartSound((mobj_t*)&ceiling->sector->soundorg,
                        //    sfx_pstop);
                        case CeilingType.FastCrushAndRaise:
                        case CeilingType.CrushAndRaise:
                            ceiling.Direction = -1;
                            break;
                    }
                }

                break;

            case -1: // down
                res = MovePlane(ceiling.Sector!, ceiling.Speed, ceiling.BottomHeight, ceiling.Crush, 1, ceiling.Direction);

                if ((game.LevelTime & 7) == 0)
                {
                    switch (ceiling.Type)
                    {
                        case CeilingType.SilentCrushAndRaise:
                            break;
                        default:
                            //S_StartSound((mobj_t*)&ceiling->sector->soundorg,
                            //    sfx_stnmov);
                            break;
                    }
                }

                if (res == Result.PastDest)
                {
                    switch (ceiling.Type)
                    {
                        case CeilingType.SilentCrushAndRaise:
                        //S_StartSound((mobj_t*)&ceiling->sector->soundorg,
                        //    sfx_pstop);
                        case CeilingType.CrushAndRaise:
                            ceiling.Speed = Ceiling.DefaultSpeed;
                            ceiling.Direction = 1;
                            break;
                        case CeilingType.FastCrushAndRaise:
                            ceiling.Direction = 1;
                            break;

                        case CeilingType.LowerAndCrush:
                        case CeilingType.LowerToFloor:
                            game.P_RemoveActiveCeiling(ceiling);
                            break;
                    }
                }
                else if (res == Result.Crushed)
                {
                    switch (ceiling.Type)
                    {
                        case CeilingType.SilentCrushAndRaise:
                        case CeilingType.CrushAndRaise:
                        case CeilingType.LowerAndCrush:
                            ceiling.Speed = Ceiling.DefaultSpeed / 8;
                            break;
                    }
                }

                break;
        }
    }

    private static int CeilingEvent(Line line, CeilingType type)
    {
        var secnum = -1;
        var rtn = 0;

        // Reactivate in-statis ceilings... for certain types.
        switch (type)
        {
            case CeilingType.FastCrushAndRaise:
            case CeilingType.SilentCrushAndRaise:
            case CeilingType.CrushAndRaise:
                DoomGame.Instance.Game.P_ActivateInStasisCeiling(line);
                break;
        }

        while ((secnum = DoomGame.Instance.Game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var sec = DoomGame.Instance.Game.Sectors[secnum];
            if (sec.SpecialData != null)
            {
                continue;
            }

            // new door thinker
            rtn = 1;
            var ceiling = new Ceiling();
            DoomGame.Instance.Game.AddThinker(ceiling);
            sec.SpecialData = ceiling;
            ceiling.Action = MoveCeiling;
            ceiling.Sector = sec;
            ceiling.Crush = false;

            switch (type)
            {
                case CeilingType.FastCrushAndRaise:
                    ceiling.Crush = true;
                    ceiling.TopHeight = sec.CeilingHeight;
                    ceiling.BottomHeight = sec.FloorHeight + (8 * Constants.FracUnit);
                    ceiling.Direction = -1;
                    ceiling.Speed = Ceiling.DefaultSpeed * 2;
                    break;

                case CeilingType.SilentCrushAndRaise:
                case CeilingType.CrushAndRaise:
                    ceiling.Crush = true;
                    ceiling.TopHeight = sec.CeilingHeight;
                    break;

                case CeilingType.LowerAndCrush:
                case CeilingType.LowerToFloor:
                    ceiling.BottomHeight = sec.FloorHeight;
                    if (type != CeilingType.LowerToFloor)
                    {
                        ceiling.BottomHeight += 8 * Constants.FracUnit;
                    }

                    ceiling.Direction = -1;
                    ceiling.Speed = Ceiling.DefaultSpeed;
                    break;

                case CeilingType.RaiseToHighest:
                    ceiling.TopHeight = DoomGame.Instance.Game.P_FindHighestCeilingSurrounding(sec);
                    ceiling.Direction = 1;
                    ceiling.Speed = Ceiling.DefaultSpeed;
                    break;
            }

            ceiling.Tag = sec.Tag;
            ceiling.Type = type;
            DoomGame.Instance.Game.P_AddActiveCeiling(ceiling);
        }

        return rtn;
    }

    public static void PlatformRaise(ActionParams actionParams)
    {
        if (actionParams.Thinker is not Platform platform)
        {
            return;
        }

        var game = DoomGame.Instance.Game;
        switch (platform.Status)
        {
            case PlatformState.Up:
                var res = MovePlane(platform.Sector!, platform.Speed, platform.High, platform.Crush, 0, 1);

                if (platform.Type is PlatformType.RaiseAndChange or PlatformType.RaiseToNearestAndChange)
                {
                    if ((game.LevelTime & 7) == 0)
                    {
                        //S_StartSound((mobj_t*)&plat->sector->soundorg,
                        //    sfx_stnmov);
                    }
                }

                if (res == Result.Crushed && !platform.Crush)
                {
                    platform.Count = platform.Wait;
                    platform.Status = PlatformState.Down;
                    //S_StartSound((mobj_t*)&plat->sector->soundorg,
                    //    sfx_pstart);
                }
                else if (res == Result.PastDest)
                {
                    platform.Count = platform.Wait;
                    platform.Status = PlatformState.Waiting;
                    //S_StartSound((mobj_t*)&plat->sector->soundorg,
                    //    sfx_pstop);

                    switch (platform.Type)
                    {
                        case PlatformType.BlazeDWUS:
                        case PlatformType.DownWaitUpStay:
                            game.P_RemoveActivePlatform(platform);
                            break;

                        case PlatformType.RaiseAndChange:
                        case PlatformType.RaiseToNearestAndChange:
                            game.P_RemoveActivePlatform(platform);
                            break;
                    }
                }

                break;

            case PlatformState.Down:
                res = MovePlane(platform.Sector!, platform.Speed, platform.Low, false, 0, -1);

                if (res == Result.PastDest)
                {
                    platform.Count = platform.Wait;
                    platform.Status = PlatformState.Waiting;
                    // S_StartSound((mobj_t*)&plat->sector->soundorg, sfx_pstop);
                }

                break;

            case PlatformState.Waiting:
                if (--platform.Count == 0)
                {
                    platform.Status = platform.Sector!.FloorHeight == platform.Low ? PlatformState.Up : PlatformState.Down;
                    // S_StartSound((mobj_t*)&plat->sector->soundorg, sfx_pstart);
                }

                break;
        }
    }

    public static int PlatformEvent(Line line, PlatformType type, int amount)
    {
        var secnum = -1;
        var rtn = 0;
        var game = DoomGame.Instance.Game;

        // Activate all <type> platforms that are in stasis
        switch (type)
        {
            case PlatformType.PerpetualRaise:
                game.P_ActivateInStasis(line.Tag);
                break;
        }

        while ((secnum = game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var sec = game.Sectors[secnum];

            if (sec.SpecialData != null)
            {
                continue;
            }

            // Find lowest & highest floors around sector
            rtn = 1;
            var plat = new Platform();
            game.AddThinker(plat);

            plat.Type = type;
            plat.Sector = sec;
            plat.Sector.SpecialData = plat;
            plat.Action = PlatformRaise;
            plat.Crush = false;
            plat.Tag = line.Tag;

            switch (type)
            {
                case PlatformType.RaiseToNearestAndChange:
                    plat.Speed = Platform.DefaultSpeed / 2;
                    sec.FloorPic = game.Sides[line.SideNum[0]].Sector.FloorPic;
                    plat.High = game.P_FindNextHighestFloor(sec, sec.FloorHeight);
                    plat.Wait = 0;
                    plat.Status = PlatformState.Up;
                    // No more damage, if applicable
                    sec.Special = 0;

                    // S_StartSound((mobj_t*)&sec->soundorg, sfx_stnmov);
                    break;

                case PlatformType.RaiseAndChange:
                    plat.Speed = Platform.DefaultSpeed / 2;
                    sec.FloorPic = game.Sides[line.SideNum[0]].Sector.FloorPic;
                    plat.High = sec.FloorHeight + amount * Constants.FracUnit;
                    plat.Wait = 0;
                    plat.Status = PlatformState.Up;

                    // S_StartSound((mobj_t*)&sec->soundorg, sfx_stnmov);
                    break;

                case PlatformType.DownWaitUpStay:
                    plat.Speed = Platform.DefaultSpeed * 4;
                    plat.Low = game.P_FindLowestFloorSurrounding(sec);

                    if (plat.Low > sec.FloorHeight)
                    {
                        plat.Low = sec.FloorHeight;
                    }

                    plat.High = sec.FloorHeight;
                    plat.Wait = 35 * Platform.DefaultWait;
                    plat.Status = PlatformState.Down;

                    // S_StartSound((mobj_t *)&sec->soundorg,sfx_pstart);
                    break;

                case PlatformType.BlazeDWUS:
                    plat.Speed = Platform.DefaultSpeed * 8;
                    plat.Low = game.P_FindLowestFloorSurrounding(sec);

                    if (plat.Low > sec.FloorHeight)
                    {
                        plat.Low = sec.FloorHeight;
                    }

                    plat.High = sec.FloorHeight;
                    plat.Wait = 35 * Platform.DefaultWait;
                    plat.Status = PlatformState.Down;

                    // S_StartSound((mobj_t *)&sec->soundorg,sfx_pstart);
                    break;

                case PlatformType.PerpetualRaise:
                    plat.Speed = Platform.DefaultSpeed;
                    plat.Low = game.P_FindLowestFloorSurrounding(sec);

                    if (plat.Low > sec.FloorHeight)
                    {
                        plat.Low = sec.FloorHeight;
                    }

                    plat.High = game.P_FindHighestFloorSurrounding(sec);

                    if (plat.High < sec.FloorHeight)
                    {
                        plat.High = sec.FloorHeight;
                    }

                    plat.Wait = 35 * Platform.DefaultWait;
                    plat.Status = (PlatformState)(DoomRandom.P_Random() & 1);

                    // S_StartSound((mobj_t *)&sec->soundorg,sfx_pstart);
                    break;
            }

            game.P_AddActivePlatform(plat);
        }

        return rtn;
    }

    private static int TeleportEvent(Line line, int side, MapObject thing)
    {
        // Don't teleport missiles
        if ((thing.Flags & MapObjectFlag.MF_MISSILE) != 0)
        {
            return 0;
        }

        // Don't teleport if hit back of line, so you can get out of teleporter.
        if (side == 1)
        {
            return 0;
        }

        var tag = line.Tag;
        var game = DoomGame.Instance.Game;
        foreach (var sector in game.Sectors.Where(x => x.Tag == tag))
        {
            for (var thinkerNode = game.Thinkers.First; thinkerNode == null || thinkerNode.Next != game.Thinkers.First; thinkerNode = thinkerNode.Next)
            {
                if (thinkerNode.Value is not MapObject m)
                {
                    continue;
                }

                // not a teleportman
                if (m.Type != MapObjectType.MT_TELEPORTMAN)
                {
                    continue;
                }

                var mapObjectSector = m.SubSector!.Sector;
                // wrong sector
                if (mapObjectSector != sector)
                {
                    continue;
                }

                var oldX = thing.X;
                var oldY = thing.Y;
                var oldZ = thing.Z;

                if (!game.P_TeleportMove(thing, m.X, m.Y))
                {
                    return 0;
                }

                thing.Z = thing.FloorZ; // fixme: not needed?
                if (thing.Player != null)
                {
                    thing.Player.ViewZ = thing.Z + thing.Player.ViewHeight;
                }

                // spawn teleport fog at source and destination
                var fog = game.P_SpawnMapObject(oldX, oldY, oldZ, MapObjectType.MT_TFOG);
                // S_StartSound(fog, sfx_telept);
                var an = m.Angle >> RenderEngine.AngleToFineShift;

                fog = game.P_SpawnMapObject(m.X + 20 * (int)RenderEngine.FineCosine[an],
                    m.Y + 20 * (int)RenderEngine.FineSine[an],
                    thing.Z, MapObjectType.MT_TFOG);

                // emit sound, where?
                //S_StartSound(fog, sfx_telept);

                // don't move for a bit
                if (thing.Player != null)
                {
                    thing.ReactionTime = 18;
                }

                thing.Angle = m.Angle;
                thing.MomX = thing.MomY = thing.MomZ = 0;
                return 1;
            }
        }

        return 0;
    }

    private static void TagLightsTurnOffEvent(Line line)
    {
        var game = DoomGame.Instance.Game;
        foreach (var sector in game.Sectors.Where(x => x.Tag == line.Tag))
        {
            var min = sector.LightLevel;
            for (var i = 0; i < sector.LineCount; i++)
            {
                var tempLine = sector.Lines[i];
                var tsec = tempLine.GetNextSector(sector);

                if (tsec == null)
                {
                    continue;
                }

                if (tsec.LightLevel < min)
                {
                    min = tsec.LightLevel;
                }
            }

            sector.LightLevel = min;
        }
    }

    private static void LightTurnOnEvent(Line line, int bright)
    {
        var game = DoomGame.Instance.Game;
        foreach (var sector in game.Sectors.Where(x => x.Tag == line.Tag))
        {
            // bright = 0 means to search
            // for highest light level
            // surrounding sector
            if (bright == 0)
            {
                for (var i = 0; i < sector.LineCount; i++)
                {
                    var tempLine = sector.Lines[i];
                    var temp = tempLine.GetNextSector(sector);

                    if (temp == null)
                    {
                        continue;
                    }

                    if (temp.LightLevel > bright)
                    {
                        bright = temp.LightLevel;
                    }
                }
            }

            sector.LightLevel = (short)bright;
        }
    }

    private static void LightStrobingEvent(Line line)
    {
        var game = DoomGame.Instance.Game;
        var secnum = -1;

        while ((secnum = game.P_FindSectorFromLineTag(line, secnum)) >= 0)
        {
            var sec = game.Sectors[secnum];
            if (sec.SpecialData != null)
            {
                continue;
            }

            SpawnStrobeFlash(sec, StrobeFlash.SlowDark, 0);
        }
    }

    private static void SpawnStrobeFlash(Sector sec, int fastOrSlow, int inSync)
    {
        var flash = new StrobeFlash();

        DoomGame.Instance.Game.AddThinker(flash);

        flash.Sector = sec;
        flash.DarkTime = fastOrSlow;
        flash.BrightTime = StrobeFlash.StrobeBright;
        flash.Action = PerformStrobeFlash;
        flash.MaxLight = sec.LightLevel;
        flash.MinLight = DoomGame.Instance.Game.P_FindMinSurroundingLight(sec, sec.LightLevel);

        if (flash.MinLight == flash.MaxLight)
        {
            flash.MinLight = 0;
        }

        // nothing special about it during gameplay
        sec.Special = 0;

        if (inSync == 0)
        {
            flash.Count = (DoomRandom.P_Random() & 7) + 1;
        }
        else
        {
            flash.Count = 1;
        }
    }

    private static void PerformStrobeFlash(ActionParams actionParams)
    {
        if (actionParams.Thinker is not StrobeFlash flash)
        {
            return;
        }

        if (--flash.Count != 0)
        {
            return;
        }

        if (flash.Sector!.LightLevel == flash.MinLight)
        {
            flash.Sector.LightLevel = (short)flash.MaxLight;
            flash.Count = flash.BrightTime;
        }
        else
        {
            flash.Sector.LightLevel = (short)flash.MinLight;
            flash.Count = flash.DarkTime;
        }
    }

    private static bool TwoSided(int sectorIdx, int lineIdx)
    {
        var game = DoomGame.Instance.Game;
        return (game.Sectors[sectorIdx].Lines[lineIdx].Flags & Constants.Line.TwoSided) != 0;
    }

    private static SideDef GetSide(int currentSector, int lineIdx, int sideIdx)
    {
        var game = DoomGame.Instance.Game;
        return game.Sides[game.Sectors[currentSector].Lines[lineIdx].SideNum[sideIdx]];
    }

    private static Sector GetSector(int currentSector, int lineIdx, int sideIdx)
    {
        return GetSide(currentSector, lineIdx, sideIdx).Sector;
    }

    private static bool IsSideSectorCurrent(int currentSector, int lineIdx, int sideIdx)
    {
        var game = DoomGame.Instance.Game;
        var side = GetSide(currentSector, lineIdx, sideIdx);
        return game.Sectors.IndexOf(side.Sector) == currentSector;
    }
}
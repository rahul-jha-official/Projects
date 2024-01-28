namespace OnlineSchedulerApp.Model;

public partial class Slots
{
    private readonly Dictionary<int, SlotDetail> _slots;

    public Slots()
    {
        _slots = new()
        {
            [0] = new SlotDetail
            {
                Name = "0-1",
                Start = 0, 
                End = 1,
            },
            [1] = new SlotDetail
            {
                Name = "1-2",
                Start = 1,
                End = 2,
            },
            [2] = new SlotDetail
            {
                Name = "2-3",
                Start = 2,
                End = 3
            },
            [3] = new SlotDetail
            {
                Name = "3-4",
                Start = 3,
                End = 4
            },
            [4] = new SlotDetail
            {
                Name = "4-5",
                Start = 4,
                End = 5
            },
            [5] = new SlotDetail
            {
                Name = "5-6",
                Start = 5,
                End = 6
            },
            [6] = new SlotDetail
            {
                Name = "6-7",
                Start = 6,
                End = 7
            },
            [7] = new SlotDetail
            {
                Name = "7-8",
                Start = 7,
                End = 8
            },
            [8] = new SlotDetail
            {
                Name = "8-9",
                Start = 8,
                End = 9
            },
            [9] = new SlotDetail
            {
                Name = "9-10",
                Start = 9,
                End = 10
            },
            [10] = new SlotDetail
            {
                Name = "10-11",
                Start = 10,
                End = 11
            },
            [11] = new SlotDetail
            {
                Name = "11-12",
                Start = 11,
                End = 12
            },
            [12] = new SlotDetail
            {
                Name = "12-13",
                Start = 12,
                End = 13
            },
            [13] = new SlotDetail
            {
                Name = "13-14",
                Start = 13,
                End = 14
            },
            [14] = new SlotDetail
            {
                Name = "14-15",
                Start = 14,
                End = 15
            },
            [15] = new SlotDetail
            {
                Name = "15-16",
                Start = 15,
                End = 16
            },
            [16] = new SlotDetail
            {
                Name = "16-17",
                Start = 16,
                End = 17
            },
            [17] = new SlotDetail
            {
                Name = "17-18",
                Start = 17,
                End = 18
            },
            [18] = new SlotDetail
            {
                Name = "18-19",
                Start = 18,
                End = 19
            },
            [19] = new SlotDetail
            {
                Name = "19-20",
                Start = 19,
                End = 20
            },
            [20] = new SlotDetail
            {
                Name = "20-21",
                Start = 20,
                End = 21
            },
            [21] = new SlotDetail
            {
                Name = "21-22",
                Start = 21,
                End = 22
            },
            [22] = new SlotDetail
            {
                Name = "22-23",
                Start = 22,
                End = 23
            },
            [23] = new SlotDetail
            {
                Name = "23-24",
                Start = 23,
                End = 24
            }
        };
    }
    public int Count => _slots.Count;
    public SlotDetail[] All => _slots.Values.ToArray();
    public SlotDetail FindSlot(int slotId)
    {
        if (!_slots.ContainsKey(slotId))
        {
            throw new ArgumentException("Invalid Slot ID.");
        }
        return _slots[slotId];
    }
}

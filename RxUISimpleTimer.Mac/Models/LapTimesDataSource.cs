﻿using System;
using AppKit;
using ReactiveUI;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.Mac.Models
{
    public class LapTimesDataSource : NSTableViewDataSource
    {
        public LapTimesDataSource(IReactiveList<LapTime> items)
        {
            Items = items;
        }

        public IReactiveList<LapTime> Items{ get; set; }

        public override nint GetRowCount(NSTableView tableView)
        {
            return (Items != null) ? Items.Count : 0;
        }
    }

    public class LapTimesViewDelegate : NSTableViewDelegate
    {
        readonly LapTimesDataSource DataSource;

        public LapTimesViewDelegate(LapTimesDataSource source)
        {
            DataSource = source;
        }

        const string ColumnIdentifierLap = "Lap";
        const string ColumnIdentifierElapsed = "Elapsed";
        const string ColumnIdentifierDuration = "Duration";
        const string FormatString = @"hh\:mm\:ss\.fff";

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            var view = (NSTableCellView)tableView.MakeView(tableColumn.Identifier, this);
            var entry = DataSource.Items[(int)row];

            switch (tableColumn.Identifier)
            {
                case ColumnIdentifierLap:
                    view.TextField.StringValue = (row + 1).ToString();
                    break;
                case ColumnIdentifierElapsed:
                    view.TextField.StringValue = entry.Elapsed.ToString(FormatString);
                    break;
                case ColumnIdentifierDuration:
                    view.TextField.StringValue = entry.Duration.ToString(FormatString);
                    break;
            }

            return view;
        }

        public override bool ShouldSelectRow(NSTableView tableView, nint row)
        {
            return true;
        }

        public override bool ShouldReorder(NSTableView tableView, nint columnIndex, nint newColumnIndex)
        {
            return false;
        }
    }
}


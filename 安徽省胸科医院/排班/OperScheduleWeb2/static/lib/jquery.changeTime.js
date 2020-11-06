(function ($) {
  $.fn.changeTime = function (opts) {
      var ps = $.extend({
        handler: null,
        objData: null,
        onStart: function () { },
        onChange: function () { },
        onStop: function () { }
      }, opts);

      var changeObj = {
        change: function (e) {   
          var changeData = e.data.changeData;
          var nl = e.clientX - changeData.tclientX
          changeData.nl = nl
          changeData.onChange(e);
        },
        stop: function (e) {
          e.data.changeData.onStop(e);

          document.body.onselectstart = function () { return true; }
          e.data.changeData.target.css('-moz-user-select', '');
          $(document).unbind('mousemove', changeObj.change)
            .unbind('mouseup', changeObj.stop);
        }
      }
      return this.each(function () {
        var me = this;
        var handler = null;
        if (typeof ps.handler == 'undefined' || ps.handler == null)
          handler = $(me);
        else
          handler = (typeof ps.handler == 'string' ? $(ps.handler, this) : ps.handle);
        handler.bind('mousedown', { e: me }, function (s) {
            var target = $(s.data.e);
            var changeData = {
              onChange: ps.onChange,
              onStop: ps.onStop,
              target: target,
              tclientX: s.clientX
            }

            document.body.onselectstart = function () { return false; }
            target.css('-moz-user-select', 'none');

            ps.onStart(s)
            $(document).bind('mousemove', { changeData: changeData }, changeObj.change)
                .bind('mouseup', { changeData: changeData }, changeObj.stop);
        });
    });
  }
})(jQuery);
{% assign artists = site.songs | group_by: 'artist' | sort: 'name' %} 
{%- for artist in artists -%} 
{% assign songs = artist.items | sort: 'title' %} 
{%- for song in songs -%}
<a href="{{song.url}}">{{song.artist}} - {{song.title}}</a><br />
{% endfor %} {% endfor %}


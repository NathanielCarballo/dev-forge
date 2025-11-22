# -*- coding: utf-8 -*-
"""
Created on Wed Jan 13 09:32:54 2021

@author: Nathaniel Carballo
"""

dict_states = {
        'Alabama' : 'Montgomery',
        'Alaska' : 'Juneau',
        'Arizona' : 'Phoenix',
        'Arkansas' : 'Little Rock',
        'California' : 'Sacramento',
        'Colorado' : 'Denver',
        'Connecticut' : 'Hartford',
        'Delaware' : 'Dover',
        'Florida' : 'Tallahassee',
        'Georgia' : 'Atlanta',
        'Hawaii' : 'Honolulu',
        'Idaho' : 'Boise',
        'Illinois' : 'Springfield',
        'Indiana' : 'Indianapolis',
        'Iowa' : 'Des Moines',
        'Kansas' : 'Topeka',
        'Kentucky' : 'Frankfort',
        'Lousiana' : 'Baton Rouge',
        'Maine' : 'Augusta',
        'Maryland' : 'Annapolis',
        'Massachusetts' : 'Boston',
        'Michigan' : 'Lansing',
        'Minnesota' : 'St. Paul',
        'Mississippi' : 'Jackson',
        'Missouri' : 'Jefferson City',
        'Montana' : 'Helena',
        'Nebraska' : 'Lincoln',
        'Nevada' : 'Denver',
        'New Hampshire' : 'Concord',
        'New Jersey' : 'Trenton',
        'New Mexico' : 'Santa Fe',
        'New York' : 'Albany',
        'North Carolina' : 'Raleigh',
        'North Dakota' : 'Bismarck',
        'Ohio' : 'Columbus',
        'Oklahoma' : 'Oklahoma City',
        'Oregon' : 'Salem',
        'Pennsylvania' : 'Harrisburg',
        'Rhode Island' : 'Providence',
        'South Carolina' : 'Columbia',
        'South Dakota' : 'Pierre',
        'Tennessee' : 'Nashville',
        'Texas' : 'Austin',
        'Utah' : 'Salt Lake City',
        'Vermont' : 'Montpelier',
        'Virginia' : 'Richmond',
        'Washington' : 'Olympia',
        'West Virginia' : 'Charleston',
        'Wisconsin' : 'Madison',
        'Wyoming' : 'Cheyenne',
        }


print(dict_states.values())

print(dict_states.keys())

for i, (k,v) in enumerate(dict_states.items()):
    print("Index: {}, Key: {}, Value: {}".format(i, k, v))

print("Original value:",dict_states['Alaska'])
    
dict_states["Alaska"] = 'Anchorage'

print("New value:",dict_states['Alaska'])
        

    
    
   

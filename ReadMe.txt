The PMI Extraction Utility is for extracting individual CD Audio Tracks as wave files from a Pyramix (Merging Technologies) CD Image File (.pmi).

The PMI file is a standard wavefile with an additional XML Chunk (XTOC) containing table of content information for an audio CD.


PmiData.vb is the public entry point for this application, and parses the XML information.
ExtractFromPMI.vb is called to extract the individual tracks from the PMI image file and write them to disc as regaular wave files.


